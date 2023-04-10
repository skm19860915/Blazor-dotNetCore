using System.ComponentModel.DataAnnotations;

namespace Ortho.Client.Data.ViewModels.DemandInputs
{
    public class PriorityModel
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public bool? State { get; set; }
    }
}
