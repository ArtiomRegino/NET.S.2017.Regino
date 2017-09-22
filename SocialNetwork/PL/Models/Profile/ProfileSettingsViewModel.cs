using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PL.Models.Profile
{
    public class ProfileSettingsViewModel
    {
        
        [ScaffoldColumn(false)]
        public int Id { get; set; }

        [Display(Name = "E-mail:")]
        [Required(ErrorMessage = "Enter your e-mail.")]
        [RegularExpression(@"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}", ErrorMessage = "Incorrect e-mail.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Enter your password.")]
        [DataType(DataType.Password)]
        [Display(Name = "Old password:")]
        [StringLength(50, MinimumLength = 5, ErrorMessage = "Password must contain more than 5 symbols.")]
        public string OldPassword { get; set; }

        [Required(ErrorMessage = "Enter your password second time.")]
        [DataType(DataType.Password)]
        [Display(Name = "New password:")]
        [StringLength(50, MinimumLength = 5, ErrorMessage = "Password must contain more than 5 symbols.")]
        public string NewPassword { get; set; }

    }
}