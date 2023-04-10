using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ortho.Shared.Models
{
    [Table("extCustomer", Schema = "public")]
    public class ExtCustomer
    {
        [Key]
        public int customerId { get; set; }
        public string sfdcId { get; set; }
        public string name { get; set; }
        public string city { get; set; }
        public string stateOrProvince { get; set; }
        public string country { get; set; }
    }
}
