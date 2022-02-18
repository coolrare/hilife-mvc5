using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC5Course.ViewModels
{
    public class LoginViewModel : IValidatableObject
    {
        [Required]
        [StringLength(16)]
        public string Username { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [StringLength(30)]
        public string Password { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (ValidateLogin())
            {
                yield return ValidationResult.Success;
            }
            else
            {
                yield return new ValidationResult("帳號或密碼錯誤，請重新登入！",
                    new string[] { "Username", "Password" });
            }
        }

        public bool ValidateLogin()
        {
            if (this.Username == "will")
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}