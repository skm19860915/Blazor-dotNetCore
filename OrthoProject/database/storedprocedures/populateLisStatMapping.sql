-- FUNCTION: public.populateLisStatMapping(integer, integer)

-- DROP FUNCTION IF EXISTS public."populateLisStatMapping"(integer, integer);

CREATE OR REPLACE FUNCTION public."populateLisStatMapping"(
	parm1 integer,
	parm2 integer)
    RETURNS void
    LANGUAGE 'sql'
    COST 100
    VOLATILE PARALLEL UNSAFE
AS $BODY$

DELETE FROM public."demandFileStatMapping" WHERE "scenarioId" = $1 AND "lisSetId" = $2;

INSERT INTO public."demandFileStatMapping" ("scenarioId", "lisSetId", "priorityFldName", "stat")
	SELECT DISTINCT "scenarioId", "lisSetId", "priority", false as "statDefault"
	FROM public."demandData"
	WHERE "scenarioId" = $1 AND "lisSetId" = $2;

$BODY$;

ALTER FUNCTION public."populateLisStatMapping"(integer, integer)
    OWNER TO postgres;