using Ortho.Shared.Models;
using Ortho.Shared.ViewModels;
using System;

namespace Ortho.Shared.Mappings
{
    public static class LISFileColumnMapping
    {
        public static DemandFileColumnMapping ToLISFileColumnMappings(this CsvDataViewModel csvData, int listSetId, string sceanrioId)
        {
            return new DemandFileColumnMapping
            {
                scenarioId = Convert.ToInt32(sceanrioId),
                lisSetId = listSetId,
                columnNumber = csvData.Index,
                unmappedColumn = csvData.Header,
                exampleData = csvData.Data,
                fldId = null,
            };
        }
    }
}
