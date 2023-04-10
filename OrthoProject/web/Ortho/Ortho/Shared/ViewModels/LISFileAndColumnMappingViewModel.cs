using Ortho.Shared.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Ortho.Shared.ViewModels
{
    public class LISFileAndColumnMappingViewModel
    {
        [Key]
        public int LisSetId { get; set; }
        public int UserId { get; set; }
        public string FileName { get; set; }
        public int CustomerId { get; set; }
        public IEnumerable<DemandFileColumnMapping> DemandFileColumnMappings { get; set;}
    }
}
