using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ortho.Shared.Models
{
    [Table("appUser", Schema = "public")]
    public class AppUser
    {
        [Key]
        public int userId { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string title { get; set; }
    }
}
