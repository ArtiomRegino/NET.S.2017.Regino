using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace PL.Models.User
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Enter your username.")]
        [Display(Name = "Username:")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Enter your password.")]
        [DataType(DataType.Password, ErrorMessage = "Incorrect password.")]
        [Display(Name = "Password:")]
        public string Password { get; set; }
    
    }
}