using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel.DataAnnotations;

namespace Simuu
{
    public class LoginModel
    {

        #region DIRECT PROPERTIES


        [Required]
        public string UserName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        public string Message { get; set; }

        public string ReturnURL { get; set; }


        #endregion

    }
}