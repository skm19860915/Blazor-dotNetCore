using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ortho.Shared.Models
{
    [Table("demandLisFile", Schema = "public")]
    public class DemandLISFile
    {
        [Key]
        public int lisSetId { get; set; }
        public int userId { get; set; }
        public int scenarioIdFirstLoad { get; set; }
        public bool newCustomerData { get; set; }
        public string fileName { get; set; }
        public DateTime uploadDt { get; set; }
        public int customerId { get; set; }
        public string lisFile { get; set; }
    }
}
