using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ortho.Shared.Models
{
    [Table("configScenarioType", Schema = "public")]
    public class ConfigScenarioType
    {
        [Key]
        public int scenarioTypeId { get; set; }
        public string scenarioType { get; set; }
    }
}
