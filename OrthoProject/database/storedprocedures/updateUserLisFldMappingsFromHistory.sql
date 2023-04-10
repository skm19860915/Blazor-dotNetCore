-- FUNCTION: public.updateUserLisFldMappingsFromHistory(integer, integer)

-- DROP FUNCTION IF EXISTS public."updateUserLisFldMappingsFromHistory"(integer, integer);

CREATE OR REPLACE FUNCTION public."updateUserLisFldMappingsFromHistory"(
	parm1 integer,
	parm2 integer)
    RETURNS void
    LANGUAGE 'sql'
    COST 100
    VOLATILE PARALLEL UNSAFE
AS $BODY$

UPDATE public."demandFileColumnMapping"

SET "fldId" = T2."fldId"

FROM 

( SELECT "scenarioId", LOWER(REPLACE("demandFileColumnMapping"."unmappedColumn",' ','')) as unmappedColumnModified, "fldId" FROM public."demandFileColumnMapping" 
    WHERE public."demandFileColumnMapping"."scenarioId" = $2 AND public."demandFileColumnMapping"."fldId" IS NULL) AS T1
	
INNER JOIN 

( SELECT DISTINCT ON (LOWER(REPLACE("demandFileColumnMapping"."unmappedColumn",' ','')))
    LOWER(REPLACE("demandFileColumnMapping"."unmappedColumn",' ','')) as unmappedColumnModified,"creationDt", "demandFileColumnMapping"."fldId"
   FROM "demandFileColumnMapping"
     JOIN scenario ON "demandFileColumnMapping"."scenarioId" = scenario."scenarioId"
  WHERE scenario."userIdOwner" = $1 AND "demandFileColumnMapping"."fldId" IS NOT NULL
  ORDER BY LOWER(REPLACE("demandFileColumnMapping"."unmappedColumn",' ','')) DESC, scenario."creationDt" DESC,
    "demandFileColumnMapping"."fldId" DESC ) T2

ON T1.unmappedColumnModified = T2.unmappedColumnModified

WHERE LOWER(REPLACE("demandFileColumnMapping"."unmappedColumn",' ','')) = T1.unmappedColumnModified AND public."demandFileColumnMapping"."scenarioId" = $2 AND public."demandFileColumnMapping"."fldId" IS NULL;
$BODY$;

ALTER FUNCTION public."updateUserLisFldMappingsFromHistory"(integer, integer)
    OWNER TO postgres;