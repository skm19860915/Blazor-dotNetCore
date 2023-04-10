--
-- PostgreSQL database dump
--

-- Dumped from database version 13.3
-- Dumped by pg_dump version 14.1

-- Started on 2021-12-10 16:56:33

SET statement_timeout = 0;
SET lock_timeout = 0;
SET idle_in_transaction_session_timeout = 0;
SET client_encoding = 'UTF8';
SET standard_conforming_strings = on;
SELECT pg_catalog.set_config('search_path', '', false);
SET check_function_bodies = false;
SET xmloption = content;
SET client_min_messages = warning;
SET row_security = off;

SET default_tablespace = '';

SET default_table_access_method = heap;

--
-- TOC entry 200 (class 1259 OID 16417)
-- Name: appUser; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."appUser" (
    "userId" integer NOT NULL,
    active boolean DEFAULT true NOT NULL,
    "firstName" character varying,
    "lastName" character varying,
    title character varying,
    "lastLoginDt" timestamp without time zone,
    "lastRunDt" timestamp without time zone,
    admin boolean DEFAULT false
);


ALTER TABLE public."appUser" OWNER TO postgres;

--
-- TOC entry 4230 (class 0 OID 0)
-- Dependencies: 200
-- Name: TABLE "appUser"; Type: COMMENT; Schema: public; Owner: postgres
--

COMMENT ON TABLE public."appUser" IS 'Application users';


--
-- TOC entry 201 (class 1259 OID 16425)
-- Name: assayMappingGlobal; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."assayMappingGlobal" (
    "importNameId" character varying(64)[] NOT NULL,
    "assayId" integer
);


ALTER TABLE public."assayMappingGlobal" OWNER TO postgres;

--
-- TOC entry 4231 (class 0 OID 0)
-- Dependencies: 201
-- Name: TABLE "assayMappingGlobal"; Type: COMMENT; Schema: public; Owner: postgres
--

COMMENT ON TABLE public."assayMappingGlobal" IS 'Globally mapped LIS field names';


--
-- TOC entry 202 (class 1259 OID 16431)
-- Name: assayMappingScenario; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."assayMappingScenario" (
    "scenarioId" integer NOT NULL,
    "importName" character varying,
    "mappingTypeId" integer NOT NULL,
    "assayId" integer,
    "oemName" character varying,
    "panelName" character varying
);


ALTER TABLE public."assayMappingScenario" OWNER TO postgres;

--
-- TOC entry 4232 (class 0 OID 0)
-- Dependencies: 202
-- Name: TABLE "assayMappingScenario"; Type: COMMENT; Schema: public; Owner: postgres
--

COMMENT ON TABLE public."assayMappingScenario" IS 'Scenario specific mapped LIS field names';


--
-- TOC entry 203 (class 1259 OID 16437)
-- Name: assayMappingUser; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."assayMappingUser" (
    "userId" integer NOT NULL,
    "importNameId" character varying NOT NULL,
    "assayId" integer
);


ALTER TABLE public."assayMappingUser" OWNER TO postgres;

--
-- TOC entry 4233 (class 0 OID 0)
-- Dependencies: 203
-- Name: TABLE "assayMappingUser"; Type: COMMENT; Schema: public; Owner: postgres
--

COMMENT ON TABLE public."assayMappingUser" IS 'User specific mapped LIS field names';


--
-- TOC entry 204 (class 1259 OID 16443)
-- Name: automationLocationSetting; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."automationLocationSetting" (
    "scenarioId" integer NOT NULL,
    "locationName" character varying NOT NULL,
    "frontLoaded" boolean NOT NULL,
    "preSpun" boolean NOT NULL
);


ALTER TABLE public."automationLocationSetting" OWNER TO postgres;

--
-- TOC entry 205 (class 1259 OID 16449)
-- Name: configAdminModelInput; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."configAdminModelInput" (
    "inputNameId" character varying NOT NULL,
    value double precision NOT NULL
);


ALTER TABLE public."configAdminModelInput" OWNER TO postgres;

--
-- TOC entry 4234 (class 0 OID 0)
-- Dependencies: 205
-- Name: TABLE "configAdminModelInput"; Type: COMMENT; Schema: public; Owner: postgres
--

COMMENT ON TABLE public."configAdminModelInput" IS 'Names pairs for specific inputs';


--
-- TOC entry 206 (class 1259 OID 16455)
-- Name: configAssayMappingType; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."configAssayMappingType" (
    "mappingTypeId" integer NOT NULL,
    "mappingType" character varying NOT NULL
);


ALTER TABLE public."configAssayMappingType" OWNER TO postgres;

--
-- TOC entry 207 (class 1259 OID 16461)
-- Name: configAutomationComponent; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."configAutomationComponent" (
    "componentTypeId" integer NOT NULL,
    "componentTypeName" character varying NOT NULL,
    "contributeToEmptyCarrierCount" double precision NOT NULL,
    "includeInEntryRouting" boolean NOT NULL,
    "includeInExitRouting" boolean NOT NULL,
    "includeInCentrifugeRouting" boolean NOT NULL,
    "includeInAssaySpecificRouting" boolean NOT NULL
);


ALTER TABLE public."configAutomationComponent" OWNER TO postgres;

--
-- TOC entry 4235 (class 0 OID 0)
-- Dependencies: 207
-- Name: TABLE "configAutomationComponent"; Type: COMMENT; Schema: public; Owner: postgres
--

COMMENT ON TABLE public."configAutomationComponent" IS 'Valid ORTHO automation components';


--
-- TOC entry 208 (class 1259 OID 16467)
-- Name: configAutomationRoute; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."configAutomationRoute" (
    "routeId" integer NOT NULL,
    name character varying NOT NULL
);


ALTER TABLE public."configAutomationRoute" OWNER TO postgres;

--
-- TOC entry 4236 (class 0 OID 0)
-- Dependencies: 208
-- Name: TABLE "configAutomationRoute"; Type: COMMENT; Schema: public; Owner: postgres
--

COMMENT ON TABLE public."configAutomationRoute" IS 'Valid ORTHO routes';


--
-- TOC entry 241 (class 1259 OID 17305)
-- Name: configDemandSource; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."configDemandSource" (
    "demandSourceId" integer NOT NULL,
    name character varying NOT NULL
);


ALTER TABLE public."configDemandSource" OWNER TO postgres;

--
-- TOC entry 210 (class 1259 OID 16479)
-- Name: configEvent; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."configEvent" (
    "eventId" integer NOT NULL,
    event character varying NOT NULL
);


ALTER TABLE public."configEvent" OWNER TO postgres;

--
-- TOC entry 211 (class 1259 OID 16485)
-- Name: configLabType; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."configLabType" (
    "labTypeId" integer NOT NULL,
    "labType" character varying NOT NULL
);


ALTER TABLE public."configLabType" OWNER TO postgres;

--
-- TOC entry 4237 (class 0 OID 0)
-- Dependencies: 211
-- Name: TABLE "configLabType"; Type: COMMENT; Schema: public; Owner: postgres
--

COMMENT ON TABLE public."configLabType" IS 'Valid ORTHO lab types';


--
-- TOC entry 212 (class 1259 OID 16491)
-- Name: configLisField; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."configLisField" (
    "fldId" integer NOT NULL,
    "columnNumber" integer NOT NULL,
    "fldName" character varying NOT NULL
);


ALTER TABLE public."configLisField" OWNER TO postgres;

--
-- TOC entry 4238 (class 0 OID 0)
-- Dependencies: 212
-- Name: TABLE "configLisField"; Type: COMMENT; Schema: public; Owner: postgres
--

COMMENT ON TABLE public."configLisField" IS 'Valid ORTHO LIS fields (raww data is mapped to these column field types)';


--
-- TOC entry 213 (class 1259 OID 16497)
-- Name: configOrthoAnalyzer; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."configOrthoAnalyzer" (
    "analyzerId" integer NOT NULL,
    name character varying NOT NULL
);


ALTER TABLE public."configOrthoAnalyzer" OWNER TO postgres;

--
-- TOC entry 4239 (class 0 OID 0)
-- Dependencies: 213
-- Name: TABLE "configOrthoAnalyzer"; Type: COMMENT; Schema: public; Owner: postgres
--

COMMENT ON TABLE public."configOrthoAnalyzer" IS 'Valid ORTHO analyzers';


--
-- TOC entry 214 (class 1259 OID 16503)
-- Name: configOrthoAssay; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."configOrthoAssay" (
    "assayId" integer NOT NULL,
    name character varying NOT NULL
);


ALTER TABLE public."configOrthoAssay" OWNER TO postgres;

--
-- TOC entry 4240 (class 0 OID 0)
-- Dependencies: 214
-- Name: TABLE "configOrthoAssay"; Type: COMMENT; Schema: public; Owner: postgres
--

COMMENT ON TABLE public."configOrthoAssay" IS 'Valid ORTHO assays';


--
-- TOC entry 238 (class 1259 OID 17269)
-- Name: configPriorityType; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."configPriorityType" (
    "priorityId" integer NOT NULL,
    name character varying NOT NULL
);


ALTER TABLE public."configPriorityType" OWNER TO postgres;

--
-- TOC entry 240 (class 1259 OID 17285)
-- Name: configRoutingCombinationsPossible; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."configRoutingCombinationsPossible" (
    "routeCombinationId" integer NOT NULL,
    "routeId" integer NOT NULL,
    "stepId" integer NOT NULL,
    "priorityId" integer
);


ALTER TABLE public."configRoutingCombinationsPossible" OWNER TO postgres;

--
-- TOC entry 4241 (class 0 OID 0)
-- Dependencies: 240
-- Name: COLUMN "configRoutingCombinationsPossible"."routeCombinationId"; Type: COMMENT; Schema: public; Owner: postgres
--

COMMENT ON COLUMN public."configRoutingCombinationsPossible"."routeCombinationId" IS 'primary key';


--
-- TOC entry 4242 (class 0 OID 0)
-- Dependencies: 240
-- Name: COLUMN "configRoutingCombinationsPossible"."routeId"; Type: COMMENT; Schema: public; Owner: postgres
--

COMMENT ON COLUMN public."configRoutingCombinationsPossible"."routeId" IS 'The route ID - CCIA, Hemato, etc.  This will combine with step & priority to give us options for component specific routing.';


--
-- TOC entry 4243 (class 0 OID 0)
-- Dependencies: 240
-- Name: COLUMN "configRoutingCombinationsPossible"."stepId"; Type: COMMENT; Schema: public; Owner: postgres
--

COMMENT ON COLUMN public."configRoutingCombinationsPossible"."stepId" IS 'Entry, Centrifuge, Aliquote, etc.';


--
-- TOC entry 4244 (class 0 OID 0)
-- Dependencies: 240
-- Name: COLUMN "configRoutingCombinationsPossible"."priorityId"; Type: COMMENT; Schema: public; Owner: postgres
--

COMMENT ON COLUMN public."configRoutingCombinationsPossible"."priorityId" IS 'routine or STAT';


--
-- TOC entry 215 (class 1259 OID 16509)
-- Name: configScenarioEvent; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."configScenarioEvent" (
    "eventId" integer NOT NULL,
    event character varying NOT NULL
);


ALTER TABLE public."configScenarioEvent" OWNER TO postgres;

--
-- TOC entry 4245 (class 0 OID 0)
-- Dependencies: 215
-- Name: TABLE "configScenarioEvent"; Type: COMMENT; Schema: public; Owner: postgres
--

COMMENT ON TABLE public."configScenarioEvent" IS 'Valid event types for a scenario (used in the logging)';


--
-- TOC entry 242 (class 1259 OID 17338)
-- Name: configScenarioState; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."configScenarioState" (
    "stateId" integer NOT NULL,
    name character varying
);


ALTER TABLE public."configScenarioState" OWNER TO postgres;

--
-- TOC entry 4246 (class 0 OID 0)
-- Dependencies: 242
-- Name: TABLE "configScenarioState"; Type: COMMENT; Schema: public; Owner: postgres
--

COMMENT ON TABLE public."configScenarioState" IS 'The state of the scenario: Active, archived, or deleted.  We may not permanently delete the scenario, even when the user says to do so.  This may be done by a later job so data can persist for a while.';


--
-- TOC entry 217 (class 1259 OID 16527)
-- Name: configScenarioStatus; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."configScenarioStatus" (
    "statusId" integer NOT NULL,
    status character varying NOT NULL
);


ALTER TABLE public."configScenarioStatus" OWNER TO postgres;

--
-- TOC entry 4247 (class 0 OID 0)
-- Dependencies: 217
-- Name: TABLE "configScenarioStatus"; Type: COMMENT; Schema: public; Owner: postgres
--

COMMENT ON TABLE public."configScenarioStatus" IS 'Valid scenario status';


--
-- TOC entry 216 (class 1259 OID 16521)
-- Name: configScenarioType; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."configScenarioType" (
    "scenarioTypeId" integer NOT NULL,
    "scenarioType" character varying NOT NULL
);


ALTER TABLE public."configScenarioType" OWNER TO postgres;

--
-- TOC entry 4248 (class 0 OID 0)
-- Dependencies: 216
-- Name: TABLE "configScenarioType"; Type: COMMENT; Schema: public; Owner: postgres
--

COMMENT ON TABLE public."configScenarioType" IS 'Scenario types (automation, etc.)';


--
-- TOC entry 209 (class 1259 OID 16473)
-- Name: configStepsForComponentRouting; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."configStepsForComponentRouting" (
    "stepId" integer NOT NULL,
    name character varying NOT NULL
);


ALTER TABLE public."configStepsForComponentRouting" OWNER TO postgres;

--
-- TOC entry 4249 (class 0 OID 0)
-- Dependencies: 209
-- Name: TABLE "configStepsForComponentRouting"; Type: COMMENT; Schema: public; Owner: postgres
--

COMMENT ON TABLE public."configStepsForComponentRouting" IS 'Valid ORTHO steps';


--
-- TOC entry 236 (class 1259 OID 17253)
-- Name: configXtSet; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."configXtSet" (
    "xtSetId" integer NOT NULL,
    "xtSetName" character varying NOT NULL
);


ALTER TABLE public."configXtSet" OWNER TO postgres;

--
-- TOC entry 237 (class 1259 OID 17261)
-- Name: configXtSetMappingToAssay; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."configXtSetMappingToAssay" (
    "xtSetId" integer NOT NULL,
    "assayId" integer NOT NULL
);


ALTER TABLE public."configXtSetMappingToAssay" OWNER TO postgres;

--
-- TOC entry 220 (class 1259 OID 16545)
-- Name: demandData; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."demandData" (
    "lisSetId" integer NOT NULL,
    "scenarioId" integer NOT NULL,
    "arrivalDt" timestamp without time zone NOT NULL,
    "sampleId" integer NOT NULL,
    "unmappedName" character varying NOT NULL,
    "specimenType" integer NOT NULL,
    priority character varying,
    location character varying,
    "actualCompletionDt" timestamp without time zone
);


ALTER TABLE public."demandData" OWNER TO postgres;

--
-- TOC entry 4250 (class 0 OID 0)
-- Dependencies: 220
-- Name: TABLE "demandData"; Type: COMMENT; Schema: public; Owner: postgres
--

COMMENT ON TABLE public."demandData" IS 'Actual LIS file data after mapped';


--
-- TOC entry 218 (class 1259 OID 16533)
-- Name: demandFileColumnMapping; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."demandFileColumnMapping" (
    "scenarioId" integer NOT NULL,
    "columnNumber" integer NOT NULL,
    "unmappedColumn" character varying NOT NULL,
    "exampleData" character varying,
    "fldId" integer NOT NULL
);


ALTER TABLE public."demandFileColumnMapping" OWNER TO postgres;

--
-- TOC entry 4251 (class 0 OID 0)
-- Dependencies: 218
-- Name: TABLE "demandFileColumnMapping"; Type: COMMENT; Schema: public; Owner: postgres
--

COMMENT ON TABLE public."demandFileColumnMapping" IS 'LIS column mappings of the raw data to ORTHO known columns';


--
-- TOC entry 219 (class 1259 OID 16539)
-- Name: demandFileStatMapping; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."demandFileStatMapping" (
    "scenarioId" integer NOT NULL,
    "priorityFldName" character varying NOT NULL,
    stat boolean NOT NULL
);


ALTER TABLE public."demandFileStatMapping" OWNER TO postgres;

--
-- TOC entry 4252 (class 0 OID 0)
-- Dependencies: 219
-- Name: TABLE "demandFileStatMapping"; Type: COMMENT; Schema: public; Owner: postgres
--

COMMENT ON TABLE public."demandFileStatMapping" IS 'Strings that represent STAT (or routine)';


--
-- TOC entry 221 (class 1259 OID 16551)
-- Name: demandLisFile; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."demandLisFile" (
    "lisSetId" integer NOT NULL,
    "userId" integer NOT NULL,
    "scenarioIdFirstLoad" integer,
    "newCustomerData" boolean,
    "fileName" character varying NOT NULL,
    "lisFile" text[] NOT NULL,
    "uploadDt" timestamp without time zone NOT NULL,
    "customerId" integer NOT NULL
);


ALTER TABLE public."demandLisFile" OWNER TO postgres;

--
-- TOC entry 4253 (class 0 OID 0)
-- Dependencies: 221
-- Name: TABLE "demandLisFile"; Type: COMMENT; Schema: public; Owner: postgres
--

COMMENT ON TABLE public."demandLisFile" IS 'Main table records for LIS files';


--
-- TOC entry 222 (class 1259 OID 16557)
-- Name: extCustomer; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."extCustomer" (
    "customerId" integer NOT NULL,
    "sfdcId" character varying,
    "localCustomer" boolean,
    name character varying,
    city character varying,
    "stateOrProvince" character varying,
    country character varying
);


ALTER TABLE public."extCustomer" OWNER TO postgres;

--
-- TOC entry 4254 (class 0 OID 0)
-- Dependencies: 222
-- Name: TABLE "extCustomer"; Type: COMMENT; Schema: public; Owner: postgres
--

COMMENT ON TABLE public."extCustomer" IS 'Imported customer data';


--
-- TOC entry 223 (class 1259 OID 16563)
-- Name: layout; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.layout (
    "layoutId" integer NOT NULL,
    "userId" integer NOT NULL,
    "fileName" character varying NOT NULL,
    "visioFile" text[] NOT NULL,
    "importDt" timestamp without time zone NOT NULL
);


ALTER TABLE public.layout OWNER TO postgres;

--
-- TOC entry 4255 (class 0 OID 0)
-- Dependencies: 223
-- Name: TABLE layout; Type: COMMENT; Schema: public; Owner: postgres
--

COMMENT ON TABLE public.layout IS 'Visio layouts';


--
-- TOC entry 224 (class 1259 OID 16569)
-- Name: layoutCentrifugeAutomationInput; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."layoutCentrifugeAutomationInput" (
    "scenarioId" integer NOT NULL,
    "centrifugeName" character varying NOT NULL,
    "componentTypeId" integer NOT NULL,
    "batchSize" integer NOT NULL,
    "batchTimeOut" double precision NOT NULL,
    "spinTime" double precision NOT NULL
);


ALTER TABLE public."layoutCentrifugeAutomationInput" OWNER TO postgres;

--
-- TOC entry 4256 (class 0 OID 0)
-- Dependencies: 224
-- Name: TABLE "layoutCentrifugeAutomationInput"; Type: COMMENT; Schema: public; Owner: postgres
--

COMMENT ON TABLE public."layoutCentrifugeAutomationInput" IS 'Automation specific centrifuge inputs';


--
-- TOC entry 225 (class 1259 OID 16575)
-- Name: layoutComponent; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."layoutComponent" (
    "scenarioId" integer NOT NULL,
    "deviceName" character varying NOT NULL,
    "componentTypeId" integer,
    "oemName" character varying
);


ALTER TABLE public."layoutComponent" OWNER TO postgres;

--
-- TOC entry 4257 (class 0 OID 0)
-- Dependencies: 225
-- Name: TABLE "layoutComponent"; Type: COMMENT; Schema: public; Owner: postgres
--

COMMENT ON TABLE public."layoutComponent" IS 'Components in the Visio layout';


--
-- TOC entry 227 (class 1259 OID 16587)
-- Name: panelAssay; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."panelAssay" (
    "panelId" integer NOT NULL,
    "assayId" integer NOT NULL
);


ALTER TABLE public."panelAssay" OWNER TO postgres;

--
-- TOC entry 4258 (class 0 OID 0)
-- Dependencies: 227
-- Name: TABLE "panelAssay"; Type: COMMENT; Schema: public; Owner: postgres
--

COMMENT ON TABLE public."panelAssay" IS 'Mapping of panel name to assays';


--
-- TOC entry 239 (class 1259 OID 17277)
-- Name: panelGlobal; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."panelGlobal" (
    "panelId" integer NOT NULL,
    "panelName" character varying NOT NULL
);


ALTER TABLE public."panelGlobal" OWNER TO postgres;

--
-- TOC entry 226 (class 1259 OID 16581)
-- Name: panelUser; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."panelUser" (
    "panelId" integer NOT NULL,
    "userId" integer,
    "panelName" character varying
);


ALTER TABLE public."panelUser" OWNER TO postgres;

--
-- TOC entry 4259 (class 0 OID 0)
-- Dependencies: 226
-- Name: TABLE "panelUser"; Type: COMMENT; Schema: public; Owner: postgres
--

COMMENT ON TABLE public."panelUser" IS 'Panel definitions';


--
-- TOC entry 228 (class 1259 OID 16596)
-- Name: scenario; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.scenario (
    "scenarioId" integer NOT NULL,
    "userIdOwner" integer NOT NULL,
    "userIdCreator" integer NOT NULL,
    "creationDt" timestamp without time zone NOT NULL,
    nickname character varying,
    "statusId" integer NOT NULL,
    "stateId" integer DEFAULT 1 NOT NULL,
    "scenarioTypeId" integer,
    description character varying,
    practice boolean,
    "demandSource" integer,
    "newCustomer" boolean,
    "customerId" integer,
    "labTypeId" integer,
    "lisSetId" integer,
    "layoutId" integer,
    "startOfDayDt" timestamp without time zone,
    "statTatGoal" double precision,
    "routineTatGoal" double precision
);


ALTER TABLE public.scenario OWNER TO postgres;

--
-- TOC entry 4260 (class 0 OID 0)
-- Dependencies: 228
-- Name: TABLE scenario; Type: COMMENT; Schema: public; Owner: postgres
--

COMMENT ON TABLE public.scenario IS 'User scenarios';


--
-- TOC entry 4261 (class 0 OID 0)
-- Dependencies: 228
-- Name: COLUMN scenario."stateId"; Type: COMMENT; Schema: public; Owner: postgres
--

COMMENT ON COLUMN public.scenario."stateId" IS 'active, archived, deleted';


--
-- TOC entry 229 (class 1259 OID 16603)
-- Name: scenarioAnalyzerCombination; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."scenarioAnalyzerCombination" (
    "scenarioId" integer NOT NULL,
    "runNumber" integer NOT NULL,
    "analyzerId" integer NOT NULL,
    "numberOf" integer NOT NULL
);


ALTER TABLE public."scenarioAnalyzerCombination" OWNER TO postgres;

--
-- TOC entry 4262 (class 0 OID 0)
-- Dependencies: 229
-- Name: TABLE "scenarioAnalyzerCombination"; Type: COMMENT; Schema: public; Owner: postgres
--

COMMENT ON TABLE public."scenarioAnalyzerCombination" IS 'Scenario analyzer combinations simulated';


--
-- TOC entry 230 (class 1259 OID 16606)
-- Name: scenarioAutomationInput; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."scenarioAutomationInput" (
    "scenarioId" integer NOT NULL,
    "specificRouting" boolean NOT NULL,
    "numberOfCarriers" integer NOT NULL,
    "preSpinStat" boolean NOT NULL,
    "preSpinCoag" boolean NOT NULL,
    "frontLoadStat" boolean NOT NULL,
    "percentTubesFrontLoad" double precision NOT NULL,
    "trickleFeed" boolean NOT NULL,
    "reRouteHematology" boolean NOT NULL,
    "percentCciaTubesAliq" double precision NOT NULL
);


ALTER TABLE public."scenarioAutomationInput" OWNER TO postgres;

--
-- TOC entry 4263 (class 0 OID 0)
-- Dependencies: 230
-- Name: TABLE "scenarioAutomationInput"; Type: COMMENT; Schema: public; Owner: postgres
--

COMMENT ON TABLE public."scenarioAutomationInput" IS 'Sceanrio specific automation inputs';


--
-- TOC entry 232 (class 1259 OID 16612)
-- Name: scenarioEventLog; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."scenarioEventLog" (
    "scenarioId" integer NOT NULL,
    "userId" integer NOT NULL,
    "eventDt" timestamp without time zone NOT NULL,
    "eventId" integer NOT NULL
);


ALTER TABLE public."scenarioEventLog" OWNER TO postgres;

--
-- TOC entry 4264 (class 0 OID 0)
-- Dependencies: 232
-- Name: TABLE "scenarioEventLog"; Type: COMMENT; Schema: public; Owner: postgres
--

COMMENT ON TABLE public."scenarioEventLog" IS 'Events related to a scenario';


--
-- TOC entry 233 (class 1259 OID 16615)
-- Name: scenarioLabProcessInput; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."scenarioLabProcessInput" (
    "scenarioId" integer NOT NULL,
    "preCentTime" double precision,
    "decapTime" double precision,
    "percentTubesAutoValidated" double precision,
    "manualValidationTime" double precision,
    "percentStatCent" double precision,
    "percentRoutineCent" double precision,
    "numOfCents" integer,
    "centCapactiy" integer,
    "maxCentBatchWaitTime" double precision,
    "centTime" double precision
);


ALTER TABLE public."scenarioLabProcessInput" OWNER TO postgres;

--
-- TOC entry 234 (class 1259 OID 16618)
-- Name: scenarioResult; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."scenarioResult" (
    "scenarioId" integer NOT NULL,
    "runNumber" integer NOT NULL,
    "fullRun" boolean NOT NULL,
    "typeId" integer,
    "avgInstrumentTime" double precision,
    "pctStatAchieve" double precision,
    "pctRoutingAchieve" double precision,
    "avgInstTimeUtip" double precision,
    "avgInstTimeUslide" double precision,
    "avgInstTimeUwell" double precision
);


ALTER TABLE public."scenarioResult" OWNER TO postgres;

--
-- TOC entry 4265 (class 0 OID 0)
-- Dependencies: 234
-- Name: TABLE "scenarioResult"; Type: COMMENT; Schema: public; Owner: postgres
--

COMMENT ON TABLE public."scenarioResult" IS 'Results of a single run of a scenario configuration';


--
-- TOC entry 231 (class 1259 OID 16609)
-- Name: scenarioRoutingComponentEligible; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."scenarioRoutingComponentEligible" (
    "scenarioId" integer NOT NULL,
    "routeId" integer NOT NULL,
    "stepId" integer NOT NULL,
    "componentId" integer NOT NULL,
    "priorityId" integer NOT NULL
);


ALTER TABLE public."scenarioRoutingComponentEligible" OWNER TO postgres;

--
-- TOC entry 4266 (class 0 OID 0)
-- Dependencies: 231
-- Name: TABLE "scenarioRoutingComponentEligible"; Type: COMMENT; Schema: public; Owner: postgres
--

COMMENT ON TABLE public."scenarioRoutingComponentEligible" IS 'Eligible routes by scenario';


--
-- TOC entry 235 (class 1259 OID 16621)
-- Name: scenarioRoutingGridDisplay; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."scenarioRoutingGridDisplay" (
    "scenarioId" integer NOT NULL,
    "routeId" integer NOT NULL,
    "stepId" integer NOT NULL,
    "priorityId" integer NOT NULL
);


ALTER TABLE public."scenarioRoutingGridDisplay" OWNER TO postgres;

--
-- TOC entry 4267 (class 0 OID 0)
-- Dependencies: 235
-- Name: TABLE "scenarioRoutingGridDisplay"; Type: COMMENT; Schema: public; Owner: postgres
--

COMMENT ON TABLE public."scenarioRoutingGridDisplay" IS 'Stores the routing grid';


--
-- TOC entry 4181 (class 0 OID 16417)
-- Dependencies: 200
-- Data for Name: appUser; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public."appUser" ("userId", active, "firstName", "lastName", title, "lastLoginDt", "lastRunDt", admin) FROM stdin;
1	t	Amy	Greer	Principal Simulation Engineer	2021-12-10 16:48:30	2021-12-10 16:48:30	f
\.


--
-- TOC entry 4182 (class 0 OID 16425)
-- Dependencies: 201
-- Data for Name: assayMappingGlobal; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public."assayMappingGlobal" ("importNameId", "assayId") FROM stdin;
\.


--
-- TOC entry 4183 (class 0 OID 16431)
-- Dependencies: 202
-- Data for Name: assayMappingScenario; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public."assayMappingScenario" ("scenarioId", "importName", "mappingTypeId", "assayId", "oemName", "panelName") FROM stdin;
\.


--
-- TOC entry 4184 (class 0 OID 16437)
-- Dependencies: 203
-- Data for Name: assayMappingUser; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public."assayMappingUser" ("userId", "importNameId", "assayId") FROM stdin;
\.


--
-- TOC entry 4185 (class 0 OID 16443)
-- Dependencies: 204
-- Data for Name: automationLocationSetting; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public."automationLocationSetting" ("scenarioId", "locationName", "frontLoaded", "preSpun") FROM stdin;
\.


--
-- TOC entry 4186 (class 0 OID 16449)
-- Dependencies: 205
-- Data for Name: configAdminModelInput; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public."configAdminModelInput" ("inputNameId", value) FROM stdin;
\.


--
-- TOC entry 4187 (class 0 OID 16455)
-- Dependencies: 206
-- Data for Name: configAssayMappingType; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public."configAssayMappingType" ("mappingTypeId", "mappingType") FROM stdin;
1	Assay
2	Panel
3	OEM
\.


--
-- TOC entry 4188 (class 0 OID 16461)
-- Dependencies: 207
-- Data for Name: configAutomationComponent; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public."configAutomationComponent" ("componentTypeId", "componentTypeName", "contributeToEmptyCarrierCount", "includeInEntryRouting", "includeInExitRouting", "includeInCentrifugeRouting", "includeInAssaySpecificRouting") FROM stdin;
0	4600	9	f	f	f	t
1	5600	18	f	f	f	t
2	3600	9	f	f	f	t
3	OEM_Analyzer	9	f	f	f	f
4	Single_Tube_Entry	149	t	f	f	f
5	Rack_Entry	15	t	f	f	f
6	Rack_Exit	0	f	t	f	f
7	Centrifuge	13	f	f	t	f
8	Decapper	0	f	f	f	f
9	Aliquoter	43	f	f	f	f
10	Parallel_Bypass	9	f	f	f	f
11	Perpendicular_Bypass	9	f	f	f	f
12	Recapper	0	f	f	f	f
13	Conveyor_T-turn	0.6	f	f	f	f
14	Conveyor_Internal_Uturn	0.6	f	f	f	f
15	Conveyor_End_Uturn	0.6	f	f	f	f
16	Conveyor_Left_Turm	0.6	f	f	f	f
17	Conveyor_Right_Turn	0.6	f	f	f	f
18	Conveyor_Z-turn_Left	0.6	f	f	f	f
19	Conveyor_Z-turn_Right	0.6	f	f	f	f
20	Conveyor_600mm	0.6	f	f	f	f
21	Conveyor_900mm	0.9	f	f	f	f
22	Conveyor_1200mm	1.2	f	f	f	f
23	Conveyor_1500mm	1.5	f	f	f	f
24	Conveyor_1800mm	1.8	f	f	f	f
25	Conveyor_2100mm	2.1	f	f	f	f
26	Conveyor_2400mm	2.4	f	f	f	f
27	Empty_Carrier_Buffer	0	f	f	f	f
28	Validation_Buffer	50	f	f	f	f
29	Combined_Buffer	50	f	f	f	f
30	Generic_Buffer	9	f	f	f	f
31	Generic_Analyzer	0	f	f	f	f
32	Rack_Entry_Exit	15	t	t	f	f
33	ES_Flex	18	t	t	f	f
34	Cold_Storage	18	f	t	f	f
35	XT7600	18	f	f	f	t
36	XT3400	9	f	f	f	t
37	Bulk_Entry	149	t	f	f	f
\.


--
-- TOC entry 4189 (class 0 OID 16467)
-- Dependencies: 208
-- Data for Name: configAutomationRoute; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public."configAutomationRoute" ("routeId", name) FROM stdin;
1	CCIA
2	HEMATO
3	COAG
4	Aliquot
5	SpinDecap
6	Sort
7	RerouteHemato
\.


--
-- TOC entry 4222 (class 0 OID 17305)
-- Dependencies: 241
-- Data for Name: configDemandSource; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public."configDemandSource" ("demandSourceId", name) FROM stdin;
1	LIS File
2	eConn Data
3	Auto Generated
\.


--
-- TOC entry 4191 (class 0 OID 16479)
-- Dependencies: 210
-- Data for Name: configEvent; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public."configEvent" ("eventId", event) FROM stdin;
\.


--
-- TOC entry 4192 (class 0 OID 16485)
-- Dependencies: 211
-- Data for Name: configLabType; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public."configLabType" ("labTypeId", "labType") FROM stdin;
1	Hospital Lab
2	Reference/Private Lab
\.


--
-- TOC entry 4193 (class 0 OID 16491)
-- Dependencies: 212
-- Data for Name: configLisField; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public."configLisField" ("fldId", "columnNumber", "fldName") FROM stdin;
\.


--
-- TOC entry 4194 (class 0 OID 16497)
-- Dependencies: 213
-- Data for Name: configOrthoAnalyzer; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public."configOrthoAnalyzer" ("analyzerId", name) FROM stdin;
\.


--
-- TOC entry 4195 (class 0 OID 16503)
-- Dependencies: 214
-- Data for Name: configOrthoAssay; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public."configOrthoAssay" ("assayId", name) FROM stdin;
\.


--
-- TOC entry 4219 (class 0 OID 17269)
-- Dependencies: 238
-- Data for Name: configPriorityType; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public."configPriorityType" ("priorityId", name) FROM stdin;
0	Routine
1	STAT
\.


--
-- TOC entry 4221 (class 0 OID 17285)
-- Dependencies: 240
-- Data for Name: configRoutingCombinationsPossible; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public."configRoutingCombinationsPossible" ("routeCombinationId", "routeId", "stepId", "priorityId") FROM stdin;
1	1	1	1
2	1	2	1
3	1	3	\N
4	1	1	0
5	1	2	0
6	2	1	1
7	2	1	0
8	7	1	1
9	7	3	1
10	7	1	0
11	7	3	0
12	3	1	1
13	3	3	1
14	3	1	0
15	3	3	0
16	5	1	1
17	5	2	1
18	5	3	\N
19	5	1	0
20	5	2	0
21	4	1	1
22	4	2	1
23	4	3	\N
24	4	1	0
25	4	2	0
26	6	1	1
27	6	3	\N
28	6	1	0
\.


--
-- TOC entry 4196 (class 0 OID 16509)
-- Dependencies: 215
-- Data for Name: configScenarioEvent; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public."configScenarioEvent" ("eventId", event) FROM stdin;
\.


--
-- TOC entry 4223 (class 0 OID 17338)
-- Dependencies: 242
-- Data for Name: configScenarioState; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public."configScenarioState" ("stateId", name) FROM stdin;
\.


--
-- TOC entry 4198 (class 0 OID 16527)
-- Dependencies: 217
-- Data for Name: configScenarioStatus; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public."configScenarioStatus" ("statusId", status) FROM stdin;
1	In Progress
2	Run Complete
3	Published
\.


--
-- TOC entry 4197 (class 0 OID 16521)
-- Dependencies: 216
-- Data for Name: configScenarioType; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public."configScenarioType" ("scenarioTypeId", "scenarioType") FROM stdin;
1	Analyzer
2	Automation
3	XT Counts
\.


--
-- TOC entry 4190 (class 0 OID 16473)
-- Dependencies: 209
-- Data for Name: configStepsForComponentRouting; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public."configStepsForComponentRouting" ("stepId", name) FROM stdin;
1	Entry
2	Centrifuge
3	Exit
\.


--
-- TOC entry 4217 (class 0 OID 17253)
-- Dependencies: 236
-- Data for Name: configXtSet; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public."configXtSet" ("xtSetId", "xtSetName") FROM stdin;
\.


--
-- TOC entry 4218 (class 0 OID 17261)
-- Dependencies: 237
-- Data for Name: configXtSetMappingToAssay; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public."configXtSetMappingToAssay" ("xtSetId", "assayId") FROM stdin;
\.


--
-- TOC entry 4201 (class 0 OID 16545)
-- Dependencies: 220
-- Data for Name: demandData; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public."demandData" ("lisSetId", "scenarioId", "arrivalDt", "sampleId", "unmappedName", "specimenType", priority, location, "actualCompletionDt") FROM stdin;
\.


--
-- TOC entry 4199 (class 0 OID 16533)
-- Dependencies: 218
-- Data for Name: demandFileColumnMapping; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public."demandFileColumnMapping" ("scenarioId", "columnNumber", "unmappedColumn", "exampleData", "fldId") FROM stdin;
\.


--
-- TOC entry 4200 (class 0 OID 16539)
-- Dependencies: 219
-- Data for Name: demandFileStatMapping; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public."demandFileStatMapping" ("scenarioId", "priorityFldName", stat) FROM stdin;
\.


--
-- TOC entry 4202 (class 0 OID 16551)
-- Dependencies: 221
-- Data for Name: demandLisFile; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public."demandLisFile" ("lisSetId", "userId", "scenarioIdFirstLoad", "newCustomerData", "fileName", "lisFile", "uploadDt", "customerId") FROM stdin;
\.


--
-- TOC entry 4203 (class 0 OID 16557)
-- Dependencies: 222
-- Data for Name: extCustomer; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public."extCustomer" ("customerId", "sfdcId", "localCustomer", name, city, "stateOrProvince", country) FROM stdin;
1	Training	t	Customer Used for Training	Nashville	TN	37211
2	12345	f	St. Thomas Mid-Town	Nashville	TN	37211
\.


--
-- TOC entry 4204 (class 0 OID 16563)
-- Dependencies: 223
-- Data for Name: layout; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.layout ("layoutId", "userId", "fileName", "visioFile", "importDt") FROM stdin;
\.


--
-- TOC entry 4205 (class 0 OID 16569)
-- Dependencies: 224
-- Data for Name: layoutCentrifugeAutomationInput; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public."layoutCentrifugeAutomationInput" ("scenarioId", "centrifugeName", "componentTypeId", "batchSize", "batchTimeOut", "spinTime") FROM stdin;
\.


--
-- TOC entry 4206 (class 0 OID 16575)
-- Dependencies: 225
-- Data for Name: layoutComponent; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public."layoutComponent" ("scenarioId", "deviceName", "componentTypeId", "oemName") FROM stdin;
\.


--
-- TOC entry 4208 (class 0 OID 16587)
-- Dependencies: 227
-- Data for Name: panelAssay; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public."panelAssay" ("panelId", "assayId") FROM stdin;
\.


--
-- TOC entry 4220 (class 0 OID 17277)
-- Dependencies: 239
-- Data for Name: panelGlobal; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public."panelGlobal" ("panelId", "panelName") FROM stdin;
\.


--
-- TOC entry 4207 (class 0 OID 16581)
-- Dependencies: 226
-- Data for Name: panelUser; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public."panelUser" ("panelId", "userId", "panelName") FROM stdin;
\.


--
-- TOC entry 4209 (class 0 OID 16596)
-- Dependencies: 228
-- Data for Name: scenario; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.scenario ("scenarioId", "userIdOwner", "userIdCreator", "creationDt", nickname, "statusId", "stateId", "scenarioTypeId", description, practice, "demandSource", "newCustomer", "customerId", "labTypeId", "lisSetId", "layoutId", "startOfDayDt", "statTatGoal", "routineTatGoal") FROM stdin;
\.


--
-- TOC entry 4210 (class 0 OID 16603)
-- Dependencies: 229
-- Data for Name: scenarioAnalyzerCombination; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public."scenarioAnalyzerCombination" ("scenarioId", "runNumber", "analyzerId", "numberOf") FROM stdin;
\.


--
-- TOC entry 4211 (class 0 OID 16606)
-- Dependencies: 230
-- Data for Name: scenarioAutomationInput; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public."scenarioAutomationInput" ("scenarioId", "specificRouting", "numberOfCarriers", "preSpinStat", "preSpinCoag", "frontLoadStat", "percentTubesFrontLoad", "trickleFeed", "reRouteHematology", "percentCciaTubesAliq") FROM stdin;
\.


--
-- TOC entry 4213 (class 0 OID 16612)
-- Dependencies: 232
-- Data for Name: scenarioEventLog; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public."scenarioEventLog" ("scenarioId", "userId", "eventDt", "eventId") FROM stdin;
\.


--
-- TOC entry 4214 (class 0 OID 16615)
-- Dependencies: 233
-- Data for Name: scenarioLabProcessInput; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public."scenarioLabProcessInput" ("scenarioId", "preCentTime", "decapTime", "percentTubesAutoValidated", "manualValidationTime", "percentStatCent", "percentRoutineCent", "numOfCents", "centCapactiy", "maxCentBatchWaitTime", "centTime") FROM stdin;
\.


--
-- TOC entry 4215 (class 0 OID 16618)
-- Dependencies: 234
-- Data for Name: scenarioResult; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public."scenarioResult" ("scenarioId", "runNumber", "fullRun", "typeId", "avgInstrumentTime", "pctStatAchieve", "pctRoutingAchieve", "avgInstTimeUtip", "avgInstTimeUslide", "avgInstTimeUwell") FROM stdin;
\.


--
-- TOC entry 4212 (class 0 OID 16609)
-- Dependencies: 231
-- Data for Name: scenarioRoutingComponentEligible; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public."scenarioRoutingComponentEligible" ("scenarioId", "routeId", "stepId", "componentId", "priorityId") FROM stdin;
\.


--
-- TOC entry 4216 (class 0 OID 16621)
-- Dependencies: 235
-- Data for Name: scenarioRoutingGridDisplay; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public."scenarioRoutingGridDisplay" ("scenarioId", "routeId", "stepId", "priorityId") FROM stdin;
\.


--
-- TOC entry 3912 (class 2606 OID 16625)
-- Name: appUser appUser_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."appUser"
    ADD CONSTRAINT "appUser_pkey" PRIMARY KEY ("userId");


--
-- TOC entry 3918 (class 2606 OID 16627)
-- Name: automationLocationSetting automationLocationSettings_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."automationLocationSetting"
    ADD CONSTRAINT "automationLocationSettings_pkey" PRIMARY KEY ("scenarioId");


--
-- TOC entry 3936 (class 2606 OID 16629)
-- Name: configOrthoAnalyzer conficOrthoAnalyzers_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."configOrthoAnalyzer"
    ADD CONSTRAINT "conficOrthoAnalyzers_pkey" PRIMARY KEY ("analyzerId");


--
-- TOC entry 3920 (class 2606 OID 16987)
-- Name: configAdminModelInput configAdminModelInputs_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."configAdminModelInput"
    ADD CONSTRAINT "configAdminModelInputs_pkey" PRIMARY KEY ("inputNameId");


--
-- TOC entry 3922 (class 2606 OID 16633)
-- Name: configAssayMappingType configAssayMappingType_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."configAssayMappingType"
    ADD CONSTRAINT "configAssayMappingType_pkey" PRIMARY KEY ("mappingTypeId");


--
-- TOC entry 3924 (class 2606 OID 16635)
-- Name: configAutomationComponent configAutomationComponents_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."configAutomationComponent"
    ADD CONSTRAINT "configAutomationComponents_pkey" PRIMARY KEY ("componentTypeId");


--
-- TOC entry 3998 (class 2606 OID 17312)
-- Name: configDemandSource configDemandSource_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."configDemandSource"
    ADD CONSTRAINT "configDemandSource_pkey" PRIMARY KEY ("demandSourceId");


--
-- TOC entry 3930 (class 2606 OID 16637)
-- Name: configEvent configEvent_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."configEvent"
    ADD CONSTRAINT "configEvent_pkey" PRIMARY KEY ("eventId");


--
-- TOC entry 3932 (class 2606 OID 16639)
-- Name: configLabType configLabType_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."configLabType"
    ADD CONSTRAINT "configLabType_pkey" PRIMARY KEY ("labTypeId");


--
-- TOC entry 3934 (class 2606 OID 16641)
-- Name: configLisField configLisFields_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."configLisField"
    ADD CONSTRAINT "configLisFields_pkey" PRIMARY KEY ("fldId");


--
-- TOC entry 3938 (class 2606 OID 16643)
-- Name: configOrthoAssay configOrthoAssays_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."configOrthoAssay"
    ADD CONSTRAINT "configOrthoAssays_pkey" PRIMARY KEY ("assayId");


--
-- TOC entry 3990 (class 2606 OID 17276)
-- Name: configPriorityType configPriorityType_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."configPriorityType"
    ADD CONSTRAINT "configPriorityType_pkey" PRIMARY KEY ("priorityId");


--
-- TOC entry 3926 (class 2606 OID 16645)
-- Name: configAutomationRoute configRoutes_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."configAutomationRoute"
    ADD CONSTRAINT "configRoutes_pkey" PRIMARY KEY ("routeId");


--
-- TOC entry 3994 (class 2606 OID 17314)
-- Name: configRoutingCombinationsPossible configRoutingCombinationsPossible_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."configRoutingCombinationsPossible"
    ADD CONSTRAINT "configRoutingCombinationsPossible_pkey" PRIMARY KEY ("routeCombinationId");


--
-- TOC entry 3940 (class 2606 OID 16647)
-- Name: configScenarioEvent configScenarioEvents_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."configScenarioEvent"
    ADD CONSTRAINT "configScenarioEvents_pkey" PRIMARY KEY ("eventId");


--
-- TOC entry 3942 (class 2606 OID 16651)
-- Name: configScenarioType configScenarioType_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."configScenarioType"
    ADD CONSTRAINT "configScenarioType_pkey" PRIMARY KEY ("scenarioTypeId");


--
-- TOC entry 4000 (class 2606 OID 17345)
-- Name: configScenarioState configState_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."configScenarioState"
    ADD CONSTRAINT "configState_pkey" PRIMARY KEY ("stateId");


--
-- TOC entry 3944 (class 2606 OID 16653)
-- Name: configScenarioStatus configStatus_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."configScenarioStatus"
    ADD CONSTRAINT "configStatus_pkey" PRIMARY KEY ("statusId");


--
-- TOC entry 3928 (class 2606 OID 16655)
-- Name: configStepsForComponentRouting configStep_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."configStepsForComponentRouting"
    ADD CONSTRAINT "configStep_pkey" PRIMARY KEY ("stepId");


--
-- TOC entry 3988 (class 2606 OID 17260)
-- Name: configXtSet configXtSet_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."configXtSet"
    ADD CONSTRAINT "configXtSet_pkey" PRIMARY KEY ("xtSetId");


--
-- TOC entry 3953 (class 2606 OID 16657)
-- Name: extCustomer extCustomers_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."extCustomer"
    ADD CONSTRAINT "extCustomers_pkey" PRIMARY KEY ("customerId");


--
-- TOC entry 3955 (class 2606 OID 16659)
-- Name: layout layout_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.layout
    ADD CONSTRAINT layout_pkey PRIMARY KEY ("layoutId");


--
-- TOC entry 3947 (class 2606 OID 16661)
-- Name: demandFileColumnMapping lisColumnMapping_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."demandFileColumnMapping"
    ADD CONSTRAINT "lisColumnMapping_pkey" PRIMARY KEY ("scenarioId");


--
-- TOC entry 3951 (class 2606 OID 16663)
-- Name: demandLisFile lisFiles_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."demandLisFile"
    ADD CONSTRAINT "lisFiles_pkey" PRIMARY KEY ("lisSetId");


--
-- TOC entry 3915 (class 2606 OID 16665)
-- Name: assayMappingGlobal lisGlobalMapping_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."assayMappingGlobal"
    ADD CONSTRAINT "lisGlobalMapping_pkey" PRIMARY KEY ("importNameId");


--
-- TOC entry 3949 (class 2606 OID 16669)
-- Name: demandFileStatMapping lisPriority_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."demandFileStatMapping"
    ADD CONSTRAINT "lisPriority_pkey" PRIMARY KEY ("scenarioId");


--
-- TOC entry 3992 (class 2606 OID 17284)
-- Name: panelGlobal panelGlobal_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."panelGlobal"
    ADD CONSTRAINT "panelGlobal_pkey" PRIMARY KEY ("panelId");


--
-- TOC entry 3958 (class 2606 OID 16671)
-- Name: panelUser panels_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."panelUser"
    ADD CONSTRAINT panels_pkey PRIMARY KEY ("panelId");


--
-- TOC entry 3974 (class 2606 OID 16673)
-- Name: scenarioAutomationInput scenarioAutomationInputs_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."scenarioAutomationInput"
    ADD CONSTRAINT "scenarioAutomationInputs_pkey" PRIMARY KEY ("scenarioId");


--
-- TOC entry 3979 (class 2606 OID 16675)
-- Name: scenarioRoutingComponentEligible scenarioComponentRoutingElegible_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."scenarioRoutingComponentEligible"
    ADD CONSTRAINT "scenarioComponentRoutingElegible_pkey" PRIMARY KEY ("scenarioId");


--
-- TOC entry 3984 (class 2606 OID 16677)
-- Name: scenarioLabProcessInput scenarioLabProcessInputs_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."scenarioLabProcessInput"
    ADD CONSTRAINT "scenarioLabProcessInputs_pkey" PRIMARY KEY ("scenarioId");


--
-- TOC entry 3986 (class 2606 OID 16679)
-- Name: scenarioRoutingGridDisplay scenarioRoutingGridDisplay_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."scenarioRoutingGridDisplay"
    ADD CONSTRAINT "scenarioRoutingGridDisplay_pkey" PRIMARY KEY ("scenarioId");


--
-- TOC entry 3971 (class 2606 OID 16681)
-- Name: scenario scenario_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.scenario
    ADD CONSTRAINT scenario_pkey PRIMARY KEY ("scenarioId");


--
-- TOC entry 3972 (class 1259 OID 16682)
-- Name: fki_analyzer_to_configOrthoAnalyzer; Type: INDEX; Schema: public; Owner: postgres
--

CREATE INDEX "fki_analyzer_to_configOrthoAnalyzer" ON public."scenarioAnalyzerCombination" USING btree ("analyzerId");


--
-- TOC entry 3913 (class 1259 OID 16683)
-- Name: fki_assayId_to_configOrthoAssay; Type: INDEX; Schema: public; Owner: postgres
--

CREATE INDEX "fki_assayId_to_configOrthoAssay" ON public."assayMappingGlobal" USING btree ("assayId");


--
-- TOC entry 3975 (class 1259 OID 16684)
-- Name: fki_componentId_to_configAutomationComponent; Type: INDEX; Schema: public; Owner: postgres
--

CREATE INDEX "fki_componentId_to_configAutomationComponent" ON public."scenarioRoutingComponentEligible" USING btree ("componentId");


--
-- TOC entry 3956 (class 1259 OID 16685)
-- Name: fki_componentTypeId_to_configOrthoComponent; Type: INDEX; Schema: public; Owner: postgres
--

CREATE INDEX "fki_componentTypeId_to_configOrthoComponent" ON public."layoutCentrifugeAutomationInput" USING btree ("componentTypeId");


--
-- TOC entry 3960 (class 1259 OID 16686)
-- Name: fki_customerId_to_extCustomer; Type: INDEX; Schema: public; Owner: postgres
--

CREATE INDEX "fki_customerId_to_extCustomer" ON public.scenario USING btree ("customerId");


--
-- TOC entry 3961 (class 1259 OID 17337)
-- Name: fki_demandSource_to_configDemandSource; Type: INDEX; Schema: public; Owner: postgres
--

CREATE INDEX "fki_demandSource_to_configDemandSource" ON public.scenario USING btree ("demandSource");


--
-- TOC entry 3980 (class 1259 OID 16687)
-- Name: fki_eventId_to_configEvent; Type: INDEX; Schema: public; Owner: postgres
--

CREATE INDEX "fki_eventId_to_configEvent" ON public."scenarioEventLog" USING btree ("eventId");


--
-- TOC entry 3962 (class 1259 OID 16688)
-- Name: fki_labTypeId_to_configLabType; Type: INDEX; Schema: public; Owner: postgres
--

CREATE INDEX "fki_labTypeId_to_configLabType" ON public.scenario USING btree ("labTypeId");


--
-- TOC entry 3963 (class 1259 OID 16689)
-- Name: fki_layoutId_to_layout; Type: INDEX; Schema: public; Owner: postgres
--

CREATE INDEX "fki_layoutId_to_layout" ON public.scenario USING btree ("layoutId");


--
-- TOC entry 3964 (class 1259 OID 16690)
-- Name: fki_lisSetId_to_demandLisFile; Type: INDEX; Schema: public; Owner: postgres
--

CREATE INDEX "fki_lisSetId_to_demandLisFile" ON public.scenario USING btree ("lisSetId");


--
-- TOC entry 3916 (class 1259 OID 16691)
-- Name: fki_mappingTypeId_to_configMappingType; Type: INDEX; Schema: public; Owner: postgres
--

CREATE INDEX "fki_mappingTypeId_to_configMappingType" ON public."assayMappingScenario" USING btree ("mappingTypeId");


--
-- TOC entry 3945 (class 1259 OID 16692)
-- Name: fki_orthoColumnId_to_configLisField; Type: INDEX; Schema: public; Owner: postgres
--

CREATE INDEX "fki_orthoColumnId_to_configLisField" ON public."demandFileColumnMapping" USING btree ("fldId");


--
-- TOC entry 3959 (class 1259 OID 16693)
-- Name: fki_panelId_to_panel; Type: INDEX; Schema: public; Owner: postgres
--

CREATE INDEX "fki_panelId_to_panel" ON public."panelAssay" USING btree ("panelId");


--
-- TOC entry 3995 (class 1259 OID 17304)
-- Name: fki_priorityId_to_configPriorityType; Type: INDEX; Schema: public; Owner: postgres
--

CREATE INDEX "fki_priorityId_to_configPriorityType" ON public."configRoutingCombinationsPossible" USING btree ("priorityId");


--
-- TOC entry 3976 (class 1259 OID 16694)
-- Name: fki_routeId_to_configAutomationRoute; Type: INDEX; Schema: public; Owner: postgres
--

CREATE INDEX "fki_routeId_to_configAutomationRoute" ON public."scenarioRoutingComponentEligible" USING btree ("routeId");


--
-- TOC entry 3981 (class 1259 OID 16695)
-- Name: fki_scenarioId_to_scenario; Type: INDEX; Schema: public; Owner: postgres
--

CREATE INDEX "fki_scenarioId_to_scenario" ON public."scenarioEventLog" USING btree ("scenarioId");


--
-- TOC entry 3965 (class 1259 OID 16696)
-- Name: fki_scenarioTypeId_to_configScenarioType; Type: INDEX; Schema: public; Owner: postgres
--

CREATE INDEX "fki_scenarioTypeId_to_configScenarioType" ON public.scenario USING btree ("scenarioTypeId");


--
-- TOC entry 3966 (class 1259 OID 17368)
-- Name: fki_stateId_to_configScenarioState; Type: INDEX; Schema: public; Owner: postgres
--

CREATE INDEX "fki_stateId_to_configScenarioState" ON public.scenario USING btree ("stateId");


--
-- TOC entry 3967 (class 1259 OID 16697)
-- Name: fki_statusId_to_configStatus; Type: INDEX; Schema: public; Owner: postgres
--

CREATE INDEX "fki_statusId_to_configStatus" ON public.scenario USING btree ("statusId");


--
-- TOC entry 3977 (class 1259 OID 16698)
-- Name: fki_stepId_to_configAutomationStep; Type: INDEX; Schema: public; Owner: postgres
--

CREATE INDEX "fki_stepId_to_configAutomationStep" ON public."scenarioRoutingComponentEligible" USING btree ("stepId");


--
-- TOC entry 3996 (class 1259 OID 17298)
-- Name: fki_stepId_to_configStepsForComponentRouting; Type: INDEX; Schema: public; Owner: postgres
--

CREATE INDEX "fki_stepId_to_configStepsForComponentRouting" ON public."configRoutingCombinationsPossible" USING btree ("stepId");


--
-- TOC entry 3968 (class 1259 OID 16699)
-- Name: fki_userIdCreator_to_appUser; Type: INDEX; Schema: public; Owner: postgres
--

CREATE INDEX "fki_userIdCreator_to_appUser" ON public.scenario USING btree ("userIdCreator");


--
-- TOC entry 3969 (class 1259 OID 16700)
-- Name: fki_userIdOwner_to_appUser; Type: INDEX; Schema: public; Owner: postgres
--

CREATE INDEX "fki_userIdOwner_to_appUser" ON public.scenario USING btree ("userIdOwner");


--
-- TOC entry 3982 (class 1259 OID 16701)
-- Name: fki_userId_to_appUser; Type: INDEX; Schema: public; Owner: postgres
--

CREATE INDEX "fki_userId_to_appUser" ON public."scenarioEventLog" USING btree ("userId");


--
-- TOC entry 4032 (class 2606 OID 16702)
-- Name: scenarioAnalyzerCombination analyzerId_to_configOrthoAnalyzer; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."scenarioAnalyzerCombination"
    ADD CONSTRAINT "analyzerId_to_configOrthoAnalyzer" FOREIGN KEY ("analyzerId") REFERENCES public."configOrthoAnalyzer"("analyzerId") ON UPDATE CASCADE ON DELETE CASCADE NOT VALID;


--
-- TOC entry 4001 (class 2606 OID 16707)
-- Name: assayMappingGlobal assayId_to_configOrthoAssay; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."assayMappingGlobal"
    ADD CONSTRAINT "assayId_to_configOrthoAssay" FOREIGN KEY ("assayId") REFERENCES public."configOrthoAssay"("assayId") ON UPDATE CASCADE ON DELETE CASCADE NOT VALID;


--
-- TOC entry 4002 (class 2606 OID 16712)
-- Name: assayMappingScenario assayId_to_configOrthoAssay; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."assayMappingScenario"
    ADD CONSTRAINT "assayId_to_configOrthoAssay" FOREIGN KEY ("assayId") REFERENCES public."configOrthoAssay"("assayId") ON UPDATE CASCADE ON DELETE SET NULL NOT VALID;


--
-- TOC entry 4005 (class 2606 OID 16717)
-- Name: assayMappingUser assayId_to_configOrthoAssay; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."assayMappingUser"
    ADD CONSTRAINT "assayId_to_configOrthoAssay" FOREIGN KEY ("assayId") REFERENCES public."configOrthoAssay"("assayId") ON UPDATE CASCADE ON DELETE SET NULL NOT VALID;


--
-- TOC entry 4020 (class 2606 OID 16722)
-- Name: panelAssay assayId_to_configOrthoAssay; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."panelAssay"
    ADD CONSTRAINT "assayId_to_configOrthoAssay" FOREIGN KEY ("assayId") REFERENCES public."configOrthoAssay"("assayId") ON UPDATE CASCADE ON DELETE CASCADE NOT VALID;


--
-- TOC entry 4047 (class 2606 OID 17264)
-- Name: configXtSetMappingToAssay assayId_to_configOrthoAssay; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."configXtSetMappingToAssay"
    ADD CONSTRAINT "assayId_to_configOrthoAssay" FOREIGN KEY ("assayId") REFERENCES public."configOrthoAssay"("assayId") ON UPDATE CASCADE ON DELETE CASCADE NOT VALID;


--
-- TOC entry 4035 (class 2606 OID 16727)
-- Name: scenarioRoutingComponentEligible componentId_to_configAutomationComponent; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."scenarioRoutingComponentEligible"
    ADD CONSTRAINT "componentId_to_configAutomationComponent" FOREIGN KEY ("componentId") REFERENCES public."configAutomationComponent"("componentTypeId") ON UPDATE CASCADE ON DELETE SET NULL NOT VALID;


--
-- TOC entry 4015 (class 2606 OID 16732)
-- Name: layoutCentrifugeAutomationInput componentTypeId_to_configOrthoComponent; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."layoutCentrifugeAutomationInput"
    ADD CONSTRAINT "componentTypeId_to_configOrthoComponent" FOREIGN KEY ("componentTypeId") REFERENCES public."configOrthoAnalyzer"("analyzerId") ON UPDATE CASCADE ON DELETE CASCADE NOT VALID;


--
-- TOC entry 4017 (class 2606 OID 16737)
-- Name: layoutComponent componentTypeId_to_configOrthoComponent; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."layoutComponent"
    ADD CONSTRAINT "componentTypeId_to_configOrthoComponent" FOREIGN KEY ("componentTypeId") REFERENCES public."configOrthoAnalyzer"("analyzerId") ON UPDATE CASCADE ON DELETE SET NULL NOT VALID;


--
-- TOC entry 4022 (class 2606 OID 16742)
-- Name: scenario customerId_to_extCustomer; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.scenario
    ADD CONSTRAINT "customerId_to_extCustomer" FOREIGN KEY ("customerId") REFERENCES public."extCustomer"("customerId") ON UPDATE CASCADE ON DELETE SET NULL NOT VALID;


--
-- TOC entry 4012 (class 2606 OID 16747)
-- Name: demandLisFile customerId_to_extCustomer; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."demandLisFile"
    ADD CONSTRAINT "customerId_to_extCustomer" FOREIGN KEY ("customerId") REFERENCES public."extCustomer"("customerId") ON UPDATE CASCADE ON DELETE SET NULL NOT VALID;


--
-- TOC entry 4030 (class 2606 OID 17332)
-- Name: scenario demandSource_to_configDemandSource; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.scenario
    ADD CONSTRAINT "demandSource_to_configDemandSource" FOREIGN KEY ("demandSource") REFERENCES public."configDemandSource"("demandSourceId") NOT VALID;


--
-- TOC entry 4039 (class 2606 OID 16752)
-- Name: scenarioEventLog eventId_to_configEvent; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."scenarioEventLog"
    ADD CONSTRAINT "eventId_to_configEvent" FOREIGN KEY ("eventId") REFERENCES public."configEvent"("eventId") ON UPDATE CASCADE ON DELETE SET NULL NOT VALID;


--
-- TOC entry 4008 (class 2606 OID 16757)
-- Name: demandFileColumnMapping fldId_to_configLisField; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."demandFileColumnMapping"
    ADD CONSTRAINT "fldId_to_configLisField" FOREIGN KEY ("fldId") REFERENCES public."configLisField"("fldId") ON UPDATE CASCADE ON DELETE SET NULL NOT VALID;


--
-- TOC entry 4023 (class 2606 OID 16762)
-- Name: scenario labTypeId_to_configLabType; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.scenario
    ADD CONSTRAINT "labTypeId_to_configLabType" FOREIGN KEY ("labTypeId") REFERENCES public."configLabType"("labTypeId") ON UPDATE CASCADE ON DELETE SET NULL NOT VALID;


--
-- TOC entry 4024 (class 2606 OID 16767)
-- Name: scenario layoutId_to_layout; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.scenario
    ADD CONSTRAINT "layoutId_to_layout" FOREIGN KEY ("layoutId") REFERENCES public.layout("layoutId") ON UPDATE CASCADE ON DELETE SET NULL NOT VALID;


--
-- TOC entry 4025 (class 2606 OID 16772)
-- Name: scenario lisSetId_to_demandLisFile; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.scenario
    ADD CONSTRAINT "lisSetId_to_demandLisFile" FOREIGN KEY ("lisSetId") REFERENCES public."demandLisFile"("lisSetId") ON UPDATE CASCADE ON DELETE SET NULL NOT VALID;


--
-- TOC entry 4003 (class 2606 OID 16777)
-- Name: assayMappingScenario mappingTypeId_to_configMappingType; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."assayMappingScenario"
    ADD CONSTRAINT "mappingTypeId_to_configMappingType" FOREIGN KEY ("mappingTypeId") REFERENCES public."configAssayMappingType"("mappingTypeId") ON UPDATE CASCADE ON DELETE SET NULL NOT VALID;


--
-- TOC entry 4021 (class 2606 OID 16782)
-- Name: panelAssay panelId_to_panel; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."panelAssay"
    ADD CONSTRAINT "panelId_to_panel" FOREIGN KEY ("panelId") REFERENCES public."panelUser"("panelId") ON UPDATE CASCADE ON DELETE CASCADE NOT VALID;


--
-- TOC entry 4050 (class 2606 OID 17299)
-- Name: configRoutingCombinationsPossible priorityId_to_configPriorityType; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."configRoutingCombinationsPossible"
    ADD CONSTRAINT "priorityId_to_configPriorityType" FOREIGN KEY ("priorityId") REFERENCES public."configPriorityType"("priorityId") NOT VALID;


--
-- TOC entry 4036 (class 2606 OID 16787)
-- Name: scenarioRoutingComponentEligible routeId_to_configAutomationRoute; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."scenarioRoutingComponentEligible"
    ADD CONSTRAINT "routeId_to_configAutomationRoute" FOREIGN KEY ("routeId") REFERENCES public."configAutomationRoute"("routeId") ON UPDATE CASCADE ON DELETE SET NULL NOT VALID;


--
-- TOC entry 4044 (class 2606 OID 16792)
-- Name: scenarioRoutingGridDisplay routeId_to_configAutomationRoute; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."scenarioRoutingGridDisplay"
    ADD CONSTRAINT "routeId_to_configAutomationRoute" FOREIGN KEY ("routeId") REFERENCES public."configAutomationRoute"("routeId") ON UPDATE CASCADE ON DELETE SET NULL NOT VALID;


--
-- TOC entry 4048 (class 2606 OID 17288)
-- Name: configRoutingCombinationsPossible routeId_to_configAutomationRoute; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."configRoutingCombinationsPossible"
    ADD CONSTRAINT "routeId_to_configAutomationRoute" FOREIGN KEY ("routeId") REFERENCES public."configAutomationRoute"("routeId") NOT VALID;


--
-- TOC entry 4040 (class 2606 OID 16797)
-- Name: scenarioEventLog scenarioId_to_scenario; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."scenarioEventLog"
    ADD CONSTRAINT "scenarioId_to_scenario" FOREIGN KEY ("scenarioId") REFERENCES public.scenario("scenarioId") ON UPDATE CASCADE ON DELETE CASCADE NOT VALID;


--
-- TOC entry 4043 (class 2606 OID 16802)
-- Name: scenarioResult scenarioId_to_scenario; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."scenarioResult"
    ADD CONSTRAINT "scenarioId_to_scenario" FOREIGN KEY ("scenarioId") REFERENCES public.scenario("scenarioId") ON UPDATE CASCADE ON DELETE CASCADE NOT VALID;


--
-- TOC entry 4033 (class 2606 OID 16807)
-- Name: scenarioAnalyzerCombination scenarioId_to_scenario; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."scenarioAnalyzerCombination"
    ADD CONSTRAINT "scenarioId_to_scenario" FOREIGN KEY ("scenarioId") REFERENCES public.scenario("scenarioId") ON UPDATE CASCADE ON DELETE CASCADE NOT VALID;


--
-- TOC entry 4004 (class 2606 OID 16812)
-- Name: assayMappingScenario scenarioId_to_scenario; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."assayMappingScenario"
    ADD CONSTRAINT "scenarioId_to_scenario" FOREIGN KEY ("scenarioId") REFERENCES public.scenario("scenarioId") ON UPDATE CASCADE ON DELETE CASCADE NOT VALID;


--
-- TOC entry 4007 (class 2606 OID 16817)
-- Name: automationLocationSetting scenarioId_to_scenario; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."automationLocationSetting"
    ADD CONSTRAINT "scenarioId_to_scenario" FOREIGN KEY ("scenarioId") REFERENCES public.scenario("scenarioId") ON UPDATE CASCADE ON DELETE CASCADE NOT VALID;


--
-- TOC entry 4009 (class 2606 OID 16822)
-- Name: demandFileColumnMapping scenarioId_to_scenario; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."demandFileColumnMapping"
    ADD CONSTRAINT "scenarioId_to_scenario" FOREIGN KEY ("scenarioId") REFERENCES public.scenario("scenarioId") ON UPDATE CASCADE ON DELETE CASCADE NOT VALID;


--
-- TOC entry 4010 (class 2606 OID 16827)
-- Name: demandFileStatMapping scenarioId_to_scenario; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."demandFileStatMapping"
    ADD CONSTRAINT "scenarioId_to_scenario" FOREIGN KEY ("scenarioId") REFERENCES public.scenario("scenarioId") ON UPDATE CASCADE ON DELETE CASCADE NOT VALID;


--
-- TOC entry 4011 (class 2606 OID 16832)
-- Name: demandData scenarioId_to_scenario; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."demandData"
    ADD CONSTRAINT "scenarioId_to_scenario" FOREIGN KEY ("scenarioId") REFERENCES public.scenario("scenarioId") ON UPDATE CASCADE ON DELETE CASCADE NOT VALID;


--
-- TOC entry 4016 (class 2606 OID 16837)
-- Name: layoutCentrifugeAutomationInput scenarioId_to_scenario; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."layoutCentrifugeAutomationInput"
    ADD CONSTRAINT "scenarioId_to_scenario" FOREIGN KEY ("scenarioId") REFERENCES public.scenario("scenarioId") ON UPDATE CASCADE ON DELETE CASCADE NOT VALID;


--
-- TOC entry 4018 (class 2606 OID 16842)
-- Name: layoutComponent scenarioId_to_scenario; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."layoutComponent"
    ADD CONSTRAINT "scenarioId_to_scenario" FOREIGN KEY ("scenarioId") REFERENCES public.scenario("scenarioId") ON UPDATE CASCADE ON DELETE CASCADE NOT VALID;


--
-- TOC entry 4037 (class 2606 OID 16847)
-- Name: scenarioRoutingComponentEligible scenarioId_to_scenario; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."scenarioRoutingComponentEligible"
    ADD CONSTRAINT "scenarioId_to_scenario" FOREIGN KEY ("scenarioId") REFERENCES public.scenario("scenarioId") ON UPDATE CASCADE ON DELETE CASCADE NOT VALID;


--
-- TOC entry 4034 (class 2606 OID 16852)
-- Name: scenarioAutomationInput scenarioId_to_scenario; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."scenarioAutomationInput"
    ADD CONSTRAINT "scenarioId_to_scenario" FOREIGN KEY ("scenarioId") REFERENCES public.scenario("scenarioId") ON UPDATE CASCADE ON DELETE CASCADE NOT VALID;


--
-- TOC entry 4042 (class 2606 OID 16857)
-- Name: scenarioLabProcessInput scenarioId_to_scenario; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."scenarioLabProcessInput"
    ADD CONSTRAINT "scenarioId_to_scenario" FOREIGN KEY ("scenarioId") REFERENCES public.scenario("scenarioId") ON UPDATE CASCADE ON DELETE CASCADE NOT VALID;


--
-- TOC entry 4045 (class 2606 OID 16862)
-- Name: scenarioRoutingGridDisplay scenarioId_to_scenario; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."scenarioRoutingGridDisplay"
    ADD CONSTRAINT "scenarioId_to_scenario" FOREIGN KEY ("scenarioId") REFERENCES public.scenario("scenarioId") ON UPDATE CASCADE ON DELETE CASCADE NOT VALID;


--
-- TOC entry 4026 (class 2606 OID 16867)
-- Name: scenario scenarioTypeId_to_configScenarioType; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.scenario
    ADD CONSTRAINT "scenarioTypeId_to_configScenarioType" FOREIGN KEY ("scenarioTypeId") REFERENCES public."configScenarioType"("scenarioTypeId") ON UPDATE CASCADE ON DELETE SET NULL NOT VALID;


--
-- TOC entry 4031 (class 2606 OID 17363)
-- Name: scenario stateId_to_configScenarioState; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.scenario
    ADD CONSTRAINT "stateId_to_configScenarioState" FOREIGN KEY ("stateId") REFERENCES public."configScenarioState"("stateId") NOT VALID;


--
-- TOC entry 4027 (class 2606 OID 16872)
-- Name: scenario statusId_to_configStatus; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.scenario
    ADD CONSTRAINT "statusId_to_configStatus" FOREIGN KEY ("statusId") REFERENCES public."configScenarioStatus"("statusId") ON UPDATE CASCADE ON DELETE SET NULL NOT VALID;


--
-- TOC entry 4038 (class 2606 OID 16877)
-- Name: scenarioRoutingComponentEligible stepId_to_configAutomationStep; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."scenarioRoutingComponentEligible"
    ADD CONSTRAINT "stepId_to_configAutomationStep" FOREIGN KEY ("stepId") REFERENCES public."configStepsForComponentRouting"("stepId") ON UPDATE CASCADE ON DELETE SET NULL NOT VALID;


--
-- TOC entry 4046 (class 2606 OID 16882)
-- Name: scenarioRoutingGridDisplay stepId_to_configAutomationStep; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."scenarioRoutingGridDisplay"
    ADD CONSTRAINT "stepId_to_configAutomationStep" FOREIGN KEY ("stepId") REFERENCES public."configStepsForComponentRouting"("stepId") ON UPDATE CASCADE ON DELETE SET NULL NOT VALID;


--
-- TOC entry 4049 (class 2606 OID 17293)
-- Name: configRoutingCombinationsPossible stepId_to_configStepsForComponentRouting; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."configRoutingCombinationsPossible"
    ADD CONSTRAINT "stepId_to_configStepsForComponentRouting" FOREIGN KEY ("stepId") REFERENCES public."configStepsForComponentRouting"("stepId") NOT VALID;


--
-- TOC entry 4028 (class 2606 OID 16887)
-- Name: scenario userIdCreator_to_appUser; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.scenario
    ADD CONSTRAINT "userIdCreator_to_appUser" FOREIGN KEY ("userIdCreator") REFERENCES public."appUser"("userId") ON UPDATE CASCADE ON DELETE SET NULL NOT VALID;


--
-- TOC entry 4029 (class 2606 OID 16892)
-- Name: scenario userIdOwner_to_appUser; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.scenario
    ADD CONSTRAINT "userIdOwner_to_appUser" FOREIGN KEY ("userIdOwner") REFERENCES public."appUser"("userId") ON UPDATE CASCADE ON DELETE SET NULL NOT VALID;


--
-- TOC entry 4041 (class 2606 OID 16897)
-- Name: scenarioEventLog userId_to_appUser; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."scenarioEventLog"
    ADD CONSTRAINT "userId_to_appUser" FOREIGN KEY ("userId") REFERENCES public."appUser"("userId") ON UPDATE CASCADE ON DELETE CASCADE NOT VALID;


--
-- TOC entry 4006 (class 2606 OID 16902)
-- Name: assayMappingUser userId_to_appUser; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."assayMappingUser"
    ADD CONSTRAINT "userId_to_appUser" FOREIGN KEY ("assayId") REFERENCES public."configOrthoAssay"("assayId") ON UPDATE CASCADE ON DELETE CASCADE NOT VALID;


--
-- TOC entry 4013 (class 2606 OID 16907)
-- Name: demandLisFile userId_to_appUser; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."demandLisFile"
    ADD CONSTRAINT "userId_to_appUser" FOREIGN KEY ("userId") REFERENCES public."appUser"("userId") ON UPDATE CASCADE ON DELETE SET NULL NOT VALID;


--
-- TOC entry 4014 (class 2606 OID 16912)
-- Name: layout userId_to_appUser; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.layout
    ADD CONSTRAINT "userId_to_appUser" FOREIGN KEY ("userId") REFERENCES public."appUser"("userId") ON UPDATE CASCADE ON DELETE CASCADE NOT VALID;


--
-- TOC entry 4019 (class 2606 OID 16917)
-- Name: panelUser userId_to_appUser; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."panelUser"
    ADD CONSTRAINT "userId_to_appUser" FOREIGN KEY ("userId") REFERENCES public."appUser"("userId") ON UPDATE CASCADE ON DELETE CASCADE NOT VALID;


--
-- TOC entry 4229 (class 0 OID 0)
-- Dependencies: 3
-- Name: SCHEMA public; Type: ACL; Schema: -; Owner: postgres
--

REVOKE ALL ON SCHEMA public FROM rdsadmin;
REVOKE ALL ON SCHEMA public FROM PUBLIC;
GRANT ALL ON SCHEMA public TO postgres;
GRANT ALL ON SCHEMA public TO PUBLIC;


-- Completed on 2021-12-10 16:56:43

--
-- PostgreSQL database dump complete
--

