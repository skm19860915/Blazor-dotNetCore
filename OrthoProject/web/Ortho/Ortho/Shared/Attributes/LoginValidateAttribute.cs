using System.ComponentModel.DataAnnotations;

namespace Ortho.Shared.Attributes
{
    public class LoginValidateAttribute : ValidationAttribute
    {
        public string ValidPassword { get; set; }
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            ValidPassword = "0rtho$1mdb";
            var lowerValue = value.ToString().ToLower();
            if (lowerValue.Equals(ValidPassword.ToLower()))
                return null;
            return new ValidationResult(ErrorMessage, new[] { validationContext.MemberName });
        }
    }
}
