using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ortho.Shared.ViewModels
{
    public class LISDataPostViewModel
    {
        public int UserId { get; set; }
        public string FileName { get; set; }
        public string LISFileHeader { get; set; }
        public int CustomerId { get; set; }
        public string ScenarioId { get; set; }
        public List<CsvDataViewModel> csvDataList { get; set; }
    }
}
