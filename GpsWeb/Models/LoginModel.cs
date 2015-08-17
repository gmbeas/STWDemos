using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GpsWeb.Models
{
    public class LoginModel
    {
        [Display(Name = "Email", Order = 1)]
        [Required]
        [DataType(DataType.EmailAddress)]
        public string EmailAddress { get; set; }

        [DataType(DataType.Password)]
        [Display(Order = 2)]
        public string Password { get; set; }

        [Display(Name = "Remember me next time.", Order = 3)]
        public bool RememberMe { get; set; }

    }
}