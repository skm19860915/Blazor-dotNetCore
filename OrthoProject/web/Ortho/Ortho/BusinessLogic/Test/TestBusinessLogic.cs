using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

using Npgsql;
using Ortho.BusinessLogic;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;

namespace Ortho.BusinessLogic.Test
{
    class TestBusinessLogic
    {

        public static void  Main( String[] args )
        {
            System.Diagnostics.Debug.WriteLine( "Test: " + ConfigurationManager.ConnectionStrings["Test"].ConnectionString );

            using (var context = new Ortho.Server.OrthoDBContext(ConfigurationManager.ConnectionStrings["Test"].ConnectionString ))
            {
                bool bSucc = true;

                //LISFileProcessor.ImportLISData(context, 1, 7);
                
                try
                {
                    int ret = LISFileProcessor.InitializeLISHeaders(context, 1, 1, 7);
                    if (ret != LISFileProcessor.ERR_NONE)
                    {
                        // Display
                        System.Diagnostics.Debug.WriteLine(LISFileProcessor.ERR_MESSAGES[ret]);
                        bSucc = false;
                    }
                } catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine(LISFileProcessor.ERR_MESSAGES[LISFileProcessor.ERR_LIS_FILE_EXCEPTION] + ex.Message);
                    bSucc = false;
                }


                if (!bSucc)
                {
                    // remove the LIS file record??
                    // Return combo to "Select a File"
                } else
                {
                    LISFileProcessor.ImportLISData(context, 1, 7);
                }
                
            }

            System.Diagnostics.Debug.WriteLine("Success");

        }
    }
}
