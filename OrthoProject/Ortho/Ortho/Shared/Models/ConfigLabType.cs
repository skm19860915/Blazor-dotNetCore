using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ortho.Shared.Models
{
    [Table("configLabType", Schema = "public")]
    public class ConfigLabType
    {
        [Key]
        public int labTypeId { get; set; }
        public string labType { get; set; }
    }
}
