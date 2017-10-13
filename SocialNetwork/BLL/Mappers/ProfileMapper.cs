using System.Collections.Generic;
using System.Linq;
using BLL.Interfaces.Entities;
using DAL.Interface.DTO;

namespace BLL.Mappers
{
    public static class ProfileMapper
    {
        public static BllProfile ToBllProfile(this DalProfile dalProfile)
        {
            if (dalProfile == null) return null;

            var currentBllProfile = new BllProfile()
            {
                Id = dalProfile.Id,
                BirthDate = dalProfile.BirthDate,
                City = dalProfile.City,
                FirstName = dalProfile.FirstName,
                LastName = dalProfile.LastName,
                PhotoId = dalProfile.PhotoId,
                UserName = dalProfile.UserName,
                AboutMe = dalProfile.AboutMe,
                ContactPhone = dalProfile.ContactPhone,
                Gender = dalProfile.Gender
            };

            return currentBllProfile;
        }

        public static DalProfile ToDalProfile(this BllProfile bllProfile)
        {
            if (bllProfile == null) return null;

            var currentDalProfile = new DalProfile()
            {
                Id = bllProfile.Id,
                BirthDate = bllProfile.BirthDate,
                City = bllProfile.City,
                FirstName = bllProfile.FirstName,
                LastName = bllProfile.LastName,
                PhotoId = bllProfile.PhotoId,
                UserName = bllProfile.UserName,
                AboutMe = bllProfile.AboutMe,
                ContactPhone = bllProfile.ContactPhone,
                Gender = bllProfile.Gender
            };

            return currentDalProfile;
        }

        public static IEnumerable<BllProfile> Map(this IEnumerable<DalProfile> dalProfiles)
        {
            if (dalProfiles == null) return null;

            return dalProfiles.Select(item => item.ToBllProfile()).ToList();
        }
    }
}
