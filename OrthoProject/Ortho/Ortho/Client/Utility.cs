using Ortho.Client.Data.ViewModels.DemandInputs;

namespace Ortho.Client
{
    public static class Utility
    {
        public static string Time;
        public static string AccessionNumber;
        public static string Specimen;
        public static string Priority;
        public static string AssayCode;
        public static string Location;

        public static void SetLISFileParam(LISFileContentViewModel model)
        {
            if (!string.IsNullOrEmpty(model.Time))
                Time = model.Time;
            if (!string.IsNullOrEmpty(model.AccessionNumber))
                AccessionNumber = model.AccessionNumber;
            if (!string.IsNullOrEmpty(model.Specimen))
                Specimen = model.Specimen;
            if (!string.IsNullOrEmpty(model.Priority))
                Priority = model.Priority;
            if (!string.IsNullOrEmpty(model.AssayCode))
                AssayCode = model.AssayCode;
            if (!string.IsNullOrEmpty(model.Location))
                Location = model.Location;
        }
    }
}
