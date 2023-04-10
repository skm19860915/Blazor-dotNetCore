using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ortho.Shared.Models
{
    [Table("panelAssay", Schema = "public")]
    public class PanelAssay
    {
        [Key]
        public int id { get; set; }
        public int panelId { get; set; } 
        public Panel panel { get; set; }
        public int assayId { get; set; }
        public ConfigOrthoAssay assay { get; set; }
    }
}
