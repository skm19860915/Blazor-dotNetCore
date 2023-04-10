using System.ComponentModel.DataAnnotations;

namespace Ortho.Shared.ViewModels
{
    public class ScenarioStatusViewModel
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
