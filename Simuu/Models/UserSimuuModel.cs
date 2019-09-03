using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Simuu
{
    public class UserSimuuModel
    {

        #region DIRECT PROPERTIES


        public string SimuuName { get; set; }

        public int SimuuAge { get; set; }

        public DateTime SimuuBirth { get; set; }

        public DateTime SimuuDeath { get; set; }

        public string SimuuCoordinates { get; set; }

        public int ImpulseToRest { get; set; }

        public int ImpulseToDrink { get; set; }

        public int ImpulseToEat { get; set; }

        public int StatEnergy { get; set; }

        public int StatThirst { get; set; }

        public int StatHunger { get; set; }

        public int SimuuMovementSpeed { get; set; }

        public int SimuuSenseRadius { get; set; }


        #endregion


        #region INDIRECT PROPERTIES


        // ----- Users Properties ----- //
        public int UserID { get; set; }

        [Required]
        public string UserName { get; set; }

        [Required]
        public string UserEmail { get; set; }

        [DataType(DataType.Password)]
        [Compare("PasswordVerify", ErrorMessage = "Passwords do not Match")]
        [Required]
        [StringLength(Constants.MaxPasswordLength, ErrorMessage = "The {0} must be between {2} and {1} characters long.", MinimumLength = Constants.MinPasswordLength)]
        [RegularExpression(Constants.PasswordRequirements, ErrorMessage = Constants.PasswordRequirementsMessage)]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Passwords do not Match")]
        [Required]
        [StringLength(Constants.MaxPasswordLength, ErrorMessage = "The {0} must be between {2} and {1} characters long.", MinimumLength = Constants.MinPasswordLength)]
        [RegularExpression(Constants.PasswordRequirements, ErrorMessage = Constants.PasswordRequirementsMessage)]
        [Display(Name = "Verify Password")]
        public string PasswordVerify { get; set; }

        public int RoleID { get; set; }

        // ----- Roles Properties ----- //
        public string RoleName { get; set; }


        #endregion

    }
}