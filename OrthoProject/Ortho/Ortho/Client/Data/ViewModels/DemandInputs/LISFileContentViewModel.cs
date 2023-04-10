using System.ComponentModel.DataAnnotations;

namespace Ortho.Client.Data.ViewModels.DemandInputs
{
    public class LISFileContentViewModel
    {
        [Key]
        public int Id { get; set; }
        public string Time { get; set; }
        public string AccessionNumber { get; set; }
        public string Specimen { get; set; }
        public string Priority { get; set; }
        public string AssayCode { get; set; }
        public string Location { get; set; }
    }
}
