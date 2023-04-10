using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Ortho.Client.Data.ViewModels.DemandInputs
{
    public class PanelViewModel
    {
        [Key]
        public int Id { get; set; }
        public string PanelName { get; set; }
        public List<PanelContentViewModel> Contents { get; set; }
    }
}
