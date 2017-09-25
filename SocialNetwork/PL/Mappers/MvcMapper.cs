using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BLL.Interface.Entities;
using PL.Models.Profile;

namespace PL.Mappers
{
    public static class MvcMapper
    {
        public static PresentationOfProfileViewModel ToPresentation(this BllProfile bllProfile)
        {
            var profile = new PresentationOfProfileViewModel
                                     {
                                         Id = bllProfile.Id,
                                         AboutMe = bllProfile.AboutMe,
                                         BirthDate = bllProfile.BirthDate,
                                         City = bllProfile.City,
                                         ContactPhone = bllProfile.ContactPhone,
                                         FirstName = bllProfile.FirstName,
                                         Gender = bllProfile.Gender,
                                         LastName = bllProfile.LastName,
                                         PhotoId = bllProfile.PhotoId,
                                         Username = bllProfile.UserName
                                     };

            return profile;
        }
    }
}