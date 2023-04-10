using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ortho.Shared.Models
{
    [Table("demandFileColumnMapping", Schema = "public")]
    public class DemandFileColumnMapping
    {
        [Key]
        public int colMappingId { get; set; }
        public int scenarioId { get; set; }
        public int lisSetId { get; set; }
        public int columnNumber { get; set; }
        public string unmappedColumn { get; set; }
        #nullable enable
        public string? exampleData { get; set; }
        #nullable enable
        public int? fldId { get; set; }
    }
}
