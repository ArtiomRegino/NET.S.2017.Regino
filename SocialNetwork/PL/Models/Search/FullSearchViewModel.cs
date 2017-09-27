using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PL.Models.Search
{
    public class FullSearchViewModel
    {
        public int Id { get; set; }

        [Display(Name = "First name:")]
        public string FirstName { get; set; }

        [Display(Name = "Last name:")]
        public string LastName { get; set; }

        [Display(Name = "Gender:")]
        public bool? Gender { get; set; }

        [Display(Name = "Date of birth:")]
        [DataType(DataType.Date)]
        public DateTime? BirthDate { get; set; }

        [Display(Name = "City:")]
        public string City { get; set; }
    }
}