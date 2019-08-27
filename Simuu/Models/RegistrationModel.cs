using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


using System.ComponentModel.DataAnnotations;

namespace Simuu
{
    public class RegistrationModel
    {
        [Required]
        public string UserName { get; set; }

        public string UserEmail { get; set; }

        [Required]
        [StringLength(Constraints.MaxPasswordLength, ErrorMessage = "The {0} must be between {2} and {1} characters long.", MinimumLength = Constraints.MinPasswordLength)]
        [RegularExpression(Constraints.PasswordRequirements, ErrorMessage = Constraints.PasswordRequirementsMessage)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Verify Password")]
        public string PasswordVerify { get; set; }
        
        public string Message { get; set; }
    }
}