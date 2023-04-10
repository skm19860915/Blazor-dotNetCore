using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ortho.Shared.Models
{
    [Table("demandData", Schema = "public")]
    public class DemandData
    {
        [Key]
        public int demandDataId { get; set; }
        public int scenarioId { get; set; }
        public int lisSetId { get; set; }

        #nullable enable
        public string? arrivalDt { get; set; }
        #nullable enable
        public string? sampleId { get; set; }
        #nullable enable
        public string? unmappedName { get; set; }
        #nullable enable
        public string? specimenType { get; set; }
        #nullable enable
        public string? priority { get; set; }
        #nullable enable
        public string? location { get; set; }
        #nullable enable
        public string? actualCompletionDt { get; set; }
    }
}
