using Ortho.Shared.Enums;
using System;
using System.ComponentModel.DataAnnotations;

namespace Ortho.Shared.ViewModels
{
    public class ScenarioManagerViewModel
    {
        [Key]
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public string Customer { get; set; }
        public string ScenarioNickName { get; set; }
        public string Number { get; set; }
        public DateTime CreationDate { get; set; }
        public int OwnerId { get; set; }
        public string Owner { get; set; }
        public int TypeId { get; set; }
        public string Type { get; set; }
        public ScenarioStatus Status { get; set; }
        public ScenarioState State { get; set; }
        public int LisSetId { get; set; }
    }
}
