using System.ComponentModel.DataAnnotations;

namespace Ortho.Shared.ViewModels
{
    public class ScenarioDefinitionViewModel
    {
        [Key]
        public int Id { get; set; }
        public int ScenarioTypeId { get; set; }
        public string ScenarioType { get; set; }
        public string CreationDate { get; set; }
        public int CreatorId { get; set; }
        public string Creator { get; set; }
        public int OwnerId { get; set; }
        public string Owner { get; set; }
        public string OwnerTitle { get; set; }
        public string NickName { get; set; }
        public string Description { get; set; }
        public bool Mode { get; set; } = false;
        public int DemandSource { get; set; } = 1;
        public string SfdcNumber { get; set; }
        public bool CustomerType { get; set; } = true;
        public int LabType { get; set; } = 1;
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
    }
}
