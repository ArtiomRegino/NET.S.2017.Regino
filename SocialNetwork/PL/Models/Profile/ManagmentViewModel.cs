using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PL.Models.Profile
{
    public class ManagmentViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Username:")]
        public string Username { get; set; }
    }
}