using System;
using System.ComponentModel.DataAnnotations;

namespace Ortho.Shared.ViewModels
{
    public class NewScenarioViewModel
    {
        [Key]
        public int Id { get; set; }
        public int ScenarioTypeId { get; set; }
        public string ScenarioType { get; set; }
        public DateTime CreationDate { get; set; } = DateTime.Now;
        public int OwnerId { get; set; }
        public string Owner { get; set; }
        public string ScenarioNickName { get; set; }
        public int? CustomerId { get; set; }
        public string CustomerName { get; set; }
        public string SFDCNumber { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
    }
}
