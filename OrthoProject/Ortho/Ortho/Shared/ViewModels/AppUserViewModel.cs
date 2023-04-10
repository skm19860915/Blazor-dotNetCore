using System.ComponentModel.DataAnnotations;

namespace Ortho.Shared.ViewModels
{
    public class AppUserViewModel
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Title { get; set; }
    }
}
