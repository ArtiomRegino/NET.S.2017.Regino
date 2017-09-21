using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PL.Models.User
{
    public class RegistrationViewModel
    {
        [Required(ErrorMessage = "Enter your username.")]
        [Display(Name = "Username:")]
        public string UserName { get; set; }

        [Display(Name = "First name:")]
        [Required(ErrorMessage = "Enter your first name.")]
        public string FirstName { get; set; }

        [Display(Name = "Last name:")]
        [Required(ErrorMessage = "Enter your last name.")]
        public string LastName { get; set; }

        [Display(Name = "E-mail:")]
        [Required(ErrorMessage = "Enter your e-mail.")]
        [RegularExpression(@"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}", ErrorMessage = "Incorrect e-mail.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Enter your password.")]
        [DataType(DataType.Password)]
        [Display(Name = "Password:")]
        [StringLength(50, MinimumLength = 5, ErrorMessage = "Password must contain more than 5 symbols.")]
        public string Password { get; set; }

        [Compare("Password", ErrorMessage = "Passwords can't be different.")]
        [Required(ErrorMessage = "Enter your password second time.")]
        [DataType(DataType.Password)]
        [Display(Name = "Confirm your password:")]
        [StringLength(50, MinimumLength = 5, ErrorMessage = "Password must contain more than 5 symbols.")]
        public string ConfirmPassword { get; set; }

    }
}