using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ortho.Shared.Models
{
    [Table("configLisField", Schema = "public")]
    public class ConfigLISField
    {
        [Key]
        public int fldId { get; set; }
        public int columnNumber { get; set; }
        public string fldName { get; set; }
        public bool fldRequired { get; set; }
    }
}
