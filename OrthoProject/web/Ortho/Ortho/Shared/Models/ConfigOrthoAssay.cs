using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ortho.Shared.Models
{
    [Table("configOrthoAssay", Schema = "public")]
    public class ConfigOrthoAssay
    {
        [Key]
        public int assayId { get; set; }
        public string name { get; set; }
        public bool on { get; set; }
    }
}
