using Ortho.Server;
using System.Collections.Generic;
using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using System.Data.Entity;

using Ortho.Shared.Models;

namespace Ortho.BusinessLogic
{


    public class LISFileProcessor
    {

        // Captured errors
        public const int ERR_NONE = 0;
        public const int ERR_LIS_FILE_EXCEPTION = 1;
        public const int ERR_LIS_FILE_NOT_FOUND_IN_DATABASE = 2;
        public const int ERR_NO_HEADER_LINE_DETECTED = 3;
        public const int ERR_TOO_FEW_COLUMNS = 4;
        public const int ERR_LIS_NO_DATA_DETECTED = 5;
        public const int ERR_MAPPING_REQ_FLD_NOT_MAPPED = 6;
        public const int ERR_MAPPING_COLS_FAILED = 7;
        public static readonly string[] ERR_MESSAGES = { "An exception error was experienced while accessing the LIS file from the datatabse.  The exception is: ",
                                                         "The LIS file was not found in the datebase.  The file failed to import.",
                                                         "No header line was detected in the LIS file.  Check the file before importing.",
                                                         "The LIS file was imported, but there are not enough columns.  Check the file before importing.",
                                                         "A required header from the LIS file was not mapped.  Make sure all required headers are mapped.",
                                                         "The header mapping information contains an errer.  Make sure all required headers are mapped.",
                                                         "The LIS file was imported, but no data rows were detected.  Check the file and import again."};

        private const int LIS_HEADER_MIN_ORD_COUNT = 3;
        private const int LIS_SAMPLE_DATA_MAX = 100;
        private const int LIS_SAMPLE_DATA_LINE_MAX_LEN = 150;
        private const string DB_FUNCTION_UPDATE_LIS_FLD_MAPPING = "public.\"updateUserLisFldMappingsFromHistory\"";
        private const string DB_FUNCTION_POPULATE_LIS_DEMAND_DATA = "public.\"populatelisdemanddata\"";

        /// <summary>
        /// <para>This function will populate the demandFileColumnMapping for the scenario passed in.</para>
        /// 
        /// <para>IMPORTAT: It will wipe out all records for the scenario first, so only call this once when
        ///             the LIS file is first loaded.</para>
        ///
        /// <para>Results in demandFileColumnMapping populated for scenario passed in.  This function will
        ///     also attempt to match the header to ORTHO headers from configLisField.  If that fails
        ///     all of the history for the specific user in demandFileColumnMapping is checked for any
        ///     prior historical mapping.  If found, the latest match (based on scenario creation data)
        ///     is used.  Note that the code to match on historical data is in a FUNCTION in the database
        ///     called updateUserLisFldMappingsFromHistory and will do the update from inside the function</para>
        ///     
        /// <para>IMPORTANT: Header matches are made after removing all spaces and are case insensitive</para>
        ///     
        /// </summary>    
        public static int InitializeLISHeaders(OrthoDBContext dbContext, int iUser, int iScenario, int iLISId)
        {

            // Grab the row with the LIS file
            var modLISFile = dbContext.demandLisFiles.Find(iLISId);

            // Makre sure the row was found
            if (modLISFile == null)
                return ERR_LIS_FILE_NOT_FOUND_IN_DATABASE;

            String[] arrFileRows = modLISFile.lisFile.Split("\n");

            // If there are no lines, or the line is blank return an error
            if ((arrFileRows == null) || (arrFileRows.Length == 0))
                return ERR_NO_HEADER_LINE_DETECTED;

            // Grab the headers
            String[] arrHeaders = arrFileRows[0].Split(",");

            // Check the minimum number of columns - currently Time, SampleID, AssayCode
            if (arrHeaders.Length < LIS_HEADER_MIN_ORD_COUNT)
                return ERR_TOO_FEW_COLUMNS;

            // Build the samples
            String[] arrSampleRows = BuildSamples(arrHeaders, arrFileRows);

            // Map the header and write the mapping info to the database
            return MapHeaders(dbContext, iUser, iScenario, iLISId, arrHeaders, arrSampleRows);

        }

        /// <summary>
        /// <para>This function read the first 100 dat lines (lines 1-101) and build an array of sample data</para>
        /// </summary>    
        private static String[] BuildSamples(String[] arrHeaders, String[] arrFileRows)
        {
            // Continue reading the file for no more than 100 more lines and accumulate strings with sample data
            //String[] arrSamples = new string[arrHeaders.Length];
            List<String>[] arrSamples = new List<String>[arrHeaders.Length];
            for (int iRow = 1; (iRow < arrFileRows.Length) && (iRow <= LIS_SAMPLE_DATA_MAX); iRow++)
            {
                String[] arrFileData = arrFileRows[iRow].Split(",");
                for (int iHeader = 0; iHeader < arrHeaders.Length; iHeader++)
                {
                    // Initialize the array if not done yet
                    if (arrSamples[iHeader] == null)
                        arrSamples[iHeader] = new List<String>();

                    // Only add the sample data if it is not represented yet                        
                    if (!arrSamples[iHeader].Contains(arrFileData[iHeader]))
                        arrSamples[iHeader].Add(arrFileData[iHeader]);
                }
            }

            //Convert the samples to simple strings for insertion into the database
            String[] arrSampleRows = new String[arrHeaders.Length];
            for (int iHeader = 0; iHeader < arrSamples.Length; iHeader++)
                for (int iSample = 0; iSample < arrSamples[iHeader].Count; iSample++)
                    arrSampleRows[iHeader] += (iSample == 0 ? "" : ", ") + arrSamples[iHeader][iSample];

            // Truncate all strings to a MAX
            for (int iHeader = 0; iHeader < arrSamples.Length; iHeader++)
                if ( arrSampleRows[iHeader].Length > LIS_SAMPLE_DATA_LINE_MAX_LEN )
                    arrSampleRows[iHeader] = arrSampleRows[iHeader].Substring(LIS_SAMPLE_DATA_LINE_MAX_LEN);


            arrSamples = null;
            return arrSampleRows;
        }

        /// <summary>
        /// <para>This function matches unmapped column headers in two steps.  First it tries to match them to
        ///         ORTHO official headers.  Second, if that is not successful it will look at all historical
        ///         mappings for the user, and if a like unmapped header is found it will use that mapping.</para>
        /// </summary>    
        private static int MapHeaders(OrthoDBContext dbContext, int iUser, int iScenario, int iLISId, String[] arrHeaders, String[] arrSamples)
        {
            int[] arrMatchingFldIds = new int[arrHeaders.Length];   // Stores the matching fld IDs we find
            String[] arrHeadersLcTrim = new String[arrHeaders.Length];

            // Note... no errors are currently handled.  If handling an error, then make an error constant and return it.

            // Set the fld ids to -1
            for (int iHeader = 0; iHeader < arrMatchingFldIds.Length; iHeader++)
            {
                arrMatchingFldIds[iHeader] = -1;
                arrHeadersLcTrim[iHeader] = arrHeaders[iHeader].Replace(" ", "").ToLower();
            }

            // Each header needs to be first evaluated agains ORTHO headers, followed by prior mappings by the user

            // Step 1, look for matches with the official ORTHO field names
            //  Loop through the field headers from the LIS file and look for matches
            foreach (ConfigLISField fldOrtho in dbContext.configLISFields)
                for (int iHeader = 0; iHeader < arrHeaders.Length; iHeader++)
                    if (arrHeadersLcTrim[iHeader].Equals(fldOrtho.fldName.Replace(" ", "").ToLower()))
                        arrMatchingFldIds[iHeader] = fldOrtho.fldId;

            // Make sure there are no existing records
            //dbContext.demandFileColumnMapping..SingleOrDefault(x => x.WorkerId == WorkerId);
            var setRecsToDelete = dbContext.demandFileColumnMappings
                    .Where(m => m.scenarioId == iScenario);
            if (setRecsToDelete.Count() > 0)
                dbContext.demandFileColumnMappings.RemoveRange(setRecsToDelete);

            // Add the headers!
            var headers = new List<DemandFileColumnMapping>();
            for (int iHeader = 0; iHeader < arrMatchingFldIds.Length; iHeader++)
                if (arrMatchingFldIds[iHeader] >= 0)
                    headers.Add(new DemandFileColumnMapping { scenarioId = iScenario, lisSetId = iLISId, columnNumber = iHeader, unmappedColumn = arrHeaders[iHeader], exampleData = arrSamples[iHeader], fldId = arrMatchingFldIds[iHeader] });
                else
                    headers.Add(new DemandFileColumnMapping { scenarioId = iScenario, lisSetId = iLISId, columnNumber = iHeader, unmappedColumn = arrHeaders[iHeader], exampleData = arrSamples[iHeader] });

            dbContext.demandFileColumnMappings.AddRange(headers);
            headers = null;

            // Push the changes to the database
            dbContext.SaveChanges();

            // Lastly (STEP 2)... call the stored procedure to update missing mappings from historical mappings by the user
            dbContext.Database.ExecuteSqlRaw("SELECT * from " + DB_FUNCTION_UPDATE_LIS_FLD_MAPPING + "(" + iUser + "," + iScenario + ")");

            return 0;

        }

        /// <summary>
        /// <para>This function will populate the demandData database with the data from the LIS file.</para>
        /// 
        /// <para>The data from the LIS file located in demandLisFile will be added line by line to the 
        ///         table demandData.  Only the mapped lines will be added.  Mapped columns will be added
        ///         row by row to this table.  Unmapped columns will be ignored.  ORTHO official fields
        ///         are represresented by the columns of demandData.  IF a field is added, a new column
        ///         bust also be added to demandDate.</para>
        /// </summary>    
        public static int ImportLISData(OrthoDBContext dbContext, int iScenario, int iLISId)

        {
            int iMaxLisCol = 0;

            // Grab the rows with the LIS header MAPPINGs
            var mappings = from m in dbContext.demandFileColumnMappings
                           where m.scenarioId.Equals(iScenario) && m.fldId.HasValue
                           select m;

            // Remember how the LIS fields are mapped to the ortho fields - Initialize to -1
            int[] aOrthoFldIdxToLisFldIdx = new int[dbContext.configLISFields.Count()];
            for (int iFld = 0; iFld < aOrthoFldIdxToLisFldIdx.Length; iFld++)
                aOrthoFldIdxToLisFldIdx[iFld] = -1;

            // Loop through the ORTHO fields and figure out what column in the original LIS file it maps to
            // We could probably use a join here, but we are also checking for required fields that
            //  are not mapped.  This could be an outer join, but let's just do some simple loops.
            foreach (ConfigLISField fldOrtho in dbContext.configLISFields.ToList())
            {
                // Some fields MUST be mapped, check for this as we get the mappings setup
                Boolean bReqNotPresent = true;
                if (!fldOrtho.fldRequired)
                    bReqNotPresent = false;

                // Loop through the mappings and check for missing required mappings, and also build the map
                foreach (DemandFileColumnMapping mapping in mappings.ToList())
                {
                    if (mapping.fldId == fldOrtho.fldId)
                    {
                        // The ORTHO mappings are is 1 based, so convert to 0 based AND!!!!
                        //       !!!! The database arrays are 1 based, so add 1!!!! 
                        aOrthoFldIdxToLisFldIdx[fldOrtho.columnNumber - 1] = (mapping.columnNumber+1);
                        bReqNotPresent = false;

                        // Keep track of the last column we use data in
                        if (mapping.columnNumber > iMaxLisCol)
                            iMaxLisCol = mapping.columnNumber;
                    }
                }

                // If a required field was not found, then throw an error
                if (bReqNotPresent)
                    return ERR_MAPPING_REQ_FLD_NOT_MAPPED;
            }

            // We must use columns - this should never still be 0
            if (iMaxLisCol == 0)
                return ERR_MAPPING_COLS_FAILED;

            ////////////////////////////////////////////////////////////////////////////////////////////////////
            /// NOW... blow out the LIS to the 
            // Lastly (STEP 2)... call the stored procedure to update missing mappings from historical mappings by the user

            // Build out the array call
            String sOrthoFldIdxToLisFldIdx = "";
            for (int iMap = 0; iMap < aOrthoFldIdxToLisFldIdx.Length; iMap++)
                sOrthoFldIdxToLisFldIdx += (iMap == 0 ? "" : ",") + aOrthoFldIdxToLisFldIdx[iMap];

            // Call the database to copy the LIS file to the table row by row via the MAP
            dbContext.Database.ExecuteSqlRaw("SELECT " + DB_FUNCTION_POPULATE_LIS_DEMAND_DATA + "(" + iScenario + "," + iLISId + ",ARRAY[" + sOrthoFldIdxToLisFldIdx + "])");
            ////////////////////////////////////////////////////////////////////////////////////////////////////

            return 0;

        }
    }
}
