﻿using Ortho.Shared.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Ortho.Shared.ViewModels
{
    public class LISFileAndColumnMappingViewModel
    {
        [Key]
        public int Id { get; set; }
        public int UserId { get; set; }
        public string FileName { get; set; }
        public string LISFileHeader { get; set; }
        public int CustomerId { get; set; }
        public IEnumerable<DemandFileColumnMapping> DemandFileColumnMappings { get; set;}
    }
}
