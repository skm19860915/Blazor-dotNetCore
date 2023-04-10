using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ortho.Shared.Models
{
    [Table("panel", Schema = "public")]
    public class Panel
    {
        [Key]
        public int panelId { get; set; }
        public string name { get; set; }
        public int? userId { get; set; }
        public bool global { get; set; }
        public List<PanelAssay> panelAssays { get; set; }
    }
}
