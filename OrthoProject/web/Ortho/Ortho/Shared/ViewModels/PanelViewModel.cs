using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Ortho.Shared.ViewModels
{
    public class PanelViewModel
    {
        [Key]
        public int Id { get; set; }
        public string PanelName { get; set; }
        public int? UserId { get; set; }
        public List<PanelAssayViewModel> PanelAssays { get; set; }
    }
}
