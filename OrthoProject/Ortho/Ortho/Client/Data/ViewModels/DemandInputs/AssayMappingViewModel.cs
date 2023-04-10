using System.ComponentModel.DataAnnotations;

namespace Ortho.Client.Data.ViewModels.DemandInputs
{
    public class AssayMappingViewModel
    {
        [Key]
        public int Id { get; set; }
        public string AssayName { get; set; }
        public int Occurances { get; set; }
        public string MappingType { get; set; }
        public string MappingValue { get; set; }
        public bool SaveToUserMapping { get; set; }
        public bool SaveToGlobalMapping { get; set; }
    }
}
