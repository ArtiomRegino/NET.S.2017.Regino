using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PL.Models.Profile
{
    public class SmallPresentationOfProfile
    {
        public int Id { get; set; }
        [Display(Name = "First name:")]
        public string FirstName { get; set; }
        [Display(Name = "Last name:")]
        public string LastName { get; set; }
        public int? PhotoId { get; set; }
    }
}