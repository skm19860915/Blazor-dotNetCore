using Ortho.Shared.Attributes;
using System.ComponentModel.DataAnnotations;

namespace Ortho.Shared.Models
{
    public class LoginUser
    {
        [Required(ErrorMessage = "Email is required")]
        [DataType(DataType.EmailAddress)]
        [EmailAddress]
        public string Email { get; set;}
        [Required(ErrorMessage = "Password is required")]
        [LoginValidate(ErrorMessage ="Password is wrong")]
        [DataType(DataType.Password)]
        public string Password { get; set;}
    }
}
