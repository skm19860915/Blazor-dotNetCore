-- FUNCTION: public.populatelisdemanddata(integer, integer, integer[])

-- DROP FUNCTION IF EXISTS public.populatelisdemanddata(integer, integer, integer[]);

CREATE OR REPLACE FUNCTION public.populatelisdemanddata(
	scenarioid integer,
	lissetid integer,
	fldmapping integer[])
    RETURNS void
    LANGUAGE 'plpgsql'
    COST 100
    VOLATILE PARALLEL UNSAFE
AS $BODY$
  DECLARE
    
    -- Declare aliases for user input.
	scenarioId ALIAS for $1;
	lisSetId ALIAS for $2;
	arrFldMapping ALIAS for $3;
 
    -- Variabls for capturing the file contents and parsing to rows, the data items per row
	sFile TEXT;
	arrFileRows TEXT[];
	arrDataRow TEXT[];
	iRow INTEGER;
	
	-- These strings are for preparing the data for insert
	sDateTime TEXT;
	sSampleId TEXT;
	sUnmappedName TEXT;
	sSpecimenType TEXT;
	sPriority TEXT;
	sLocation TEXT;
	sActualCompletionDt TEXT;
 
 BEGIN
	-- Retrieve the customer ID number of the customer whose first and last
    --  name match the values supplied as function arguments.
    execute format('DELETE FROM public."demandData" WHERE "scenarioId" = %s', scenarioId);

	-- Retrieve the customer ID number of the customer whose first and last
    --  name match the values supplied as function arguments.
    execute format('SELECT "lisFile" FROM public."demandLisFile" WHERE "lisSetId" = %s', lisSetId) INTO sFile;

	arrFileRows := string_to_array(sFile, E'\n');

	-- Now the magic, loop through the rows and load the data into the database table demandData
 	for iRow in array_lower(arrFileRows, 1)..array_upper(arrFileRows, 1) loop
	
			-- First row is the header row, skip it
			if ( iRow = 1 ) then
				continue;
			end if;

			-- Parse the row
			arrDataRow := string_to_array(arrFileRows[iRow], ',');

			-- We build the date/time sometimes from two columns
            sDateTime := 'null';
			
			-- Concat the date and time column if they are both used
            if ( arrFldMapping[1] >= 0 ) then
                sDateTime := arrDataRow[arrFldMapping[1]];
			end if;
			
            if ( arrFldMapping[2] >= 0 ) then
				if ( arrFldMapping[1] < 0 ) then
					sDateTime := arrDataRow[arrFldMapping[2]];
				else
	                sDateTime := arrDataRow[arrFldMapping[1]] || ' ' || arrDataRow[arrFldMapping[2]];
				end if;
			end if;
			if ( sDateTime != 'null' ) then
				sDateTime := '''' || sDateTime || '''';
			end if;
			
			-- Set all to null by default
			sSampleId = 'null';
			sUnmappedName = 'null';
			sSpecimenType = 'null';
			sPriority = 'null';
			sLocation = 'null';
			sActualCompletionDt = 'null';

			if ( arrFldMapping[3] >= 0 ) then
				sSampleId = '''' || arrDataRow[arrFldMapping[3]] || '''';
			end if;
			if ( arrFldMapping[4] >= 0 ) then
				sUnmappedName = '''' || arrDataRow[arrFldMapping[4]] || '''';
			end if;
			if ( arrFldMapping[5] >= 0 ) then
				sSpecimenType = '''' || arrDataRow[arrFldMapping[5]] || '''';
			end if;
			if ( arrFldMapping[6] >= 0 ) then
				sPriority = '''' || arrDataRow[arrFldMapping[6]] || '''';
			end if;
			if ( arrFldMapping[7] >= 0 ) then
				sLocation = '''' || arrDataRow[arrFldMapping[7]] || '''';
			end if;
			if ( arrFldMapping[8] >= 0 ) then
				sActualCompletionDt = '''' || rrDataRow[arrFldMapping[8]] || '''';
			end if;
			
		    execute format('INSERT INTO public."demandData" ' ||
						   '( "scenarioId", "lisSetId", "arrivalDt", "sampleId", "unmappedName", "specimenType", "priority", "location", "actualCompletionDt" ) ' ||
						   'VALUES ( %s, %s, %s, %s, %s, %s, %s, %s, %s )',
						   scenarioId, lissetId, sDateTime, sSampleId, sUnmappedName, sSpecimenType, sPriority, sLocation, sActualCompletionDt );

	end loop;	

	raise notice 'File Contents: %', arrFileRows[1];

	END;
$BODY$;

ALTER FUNCTION public.populatelisdemanddata(integer, integer, integer[])
    OWNER TO postgres;