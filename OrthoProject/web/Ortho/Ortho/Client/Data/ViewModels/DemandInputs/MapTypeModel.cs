using System.ComponentModel.DataAnnotations;

namespace Ortho.Client.Data.ViewModels.DemandInputs
{
    public class MapTypeModel
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
