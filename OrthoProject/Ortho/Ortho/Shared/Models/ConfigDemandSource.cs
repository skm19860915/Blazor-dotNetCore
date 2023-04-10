using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ortho.Shared.Models
{
    [Table("configDemandSource", Schema ="public")]
    public class ConfigDemandSource
    {
        [Key]
        public int demandSourceId { get; set; }
        public string name { get; set; }
    }
}
