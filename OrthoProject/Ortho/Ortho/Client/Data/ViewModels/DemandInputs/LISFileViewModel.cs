namespace Ortho.Client.Data.ViewModels.DemandInputs
{
    public class LISFileViewModel
    {
        public int Id { get; set; }
        public string FileName { get; set; }
        public string FilePath { get; set; }
        public LISFileContentViewModel Data { get; set; }
    }
}
