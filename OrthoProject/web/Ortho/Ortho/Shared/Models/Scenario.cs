using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ortho.Shared.Models
{
    [Table("scenario", Schema = "public")]
    public class Scenario
    {
        [Key]
        public int scenarioId { get; set; }
        public int userIdOwner { get; set; }
        [ForeignKey("userIdOwner")]
        public AppUser userOwner { get; set; }
        public int userIdCreator { get; set; }
        [ForeignKey("userIdCreator")]
        public AppUser userCreator { get; set; }
        public DateTime creationDt { get; set; }
        public string nickname { get; set; }
        public int statusId { get; set; }
        public int stateId { get; set; }
        public int scenarioTypeId { get; set; }
        [ForeignKey("scenarioTypeId")]
        public ConfigScenarioType configScenarioType { get; set; }
        public string description { get; set; }
        public bool? practice { get; set; }
        public int? demandSource { get; set; }
        [ForeignKey("demandSource")]
        public ConfigDemandSource configDemandSource { get; set; }
        public bool newCustomer { get; set; }
        public int? customerId { get; set; }
        [ForeignKey("customerId")]
        public ExtCustomer extCustomer { get; set; }
        public int? labTypeId { get; set; }
        [ForeignKey("labTypeId")]
        public ConfigLabType configLabType { get; set; }
        public int? lisSetId { get; set; }
    }
}
