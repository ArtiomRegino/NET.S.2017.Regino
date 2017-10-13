using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Interface.DTO;
using ORM.Entities;

namespace DAL.Mappers
{
    public static class ProfileMapper
    {
        public static DalProfile ToDalProfile(this Profile ormProfile)
        {
            if (ormProfile == null) return  null;

            var currentDalProfile = new DalProfile
            {
                Id = ormProfile.Id,
                BirthDate = ormProfile.BirthDate,
                City = ormProfile.City,
                FirstName = ormProfile.FirstName,
                LastName = ormProfile.LastName,
                PhotoId = ormProfile.PhotoId,
                UserName = ormProfile.UserName,
                AboutMe = ormProfile.AboutMe,
                ContactPhone = ormProfile.ContactPhone,
                Gender = ormProfile.Gender,
            };
            return currentDalProfile;
        }

        public static Profile ToOrmProfile(this DalProfile dalProfile)
        {
            if (dalProfile == null) return null;

            var currentDalProfile = new Profile()
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

            return currentDalProfile;
        }

        public static IEnumerable<DalProfile> Map(this IQueryable<Profile> ormProfiles)
        {
            if (ormProfiles == null) return null;

            var listOfProfiles = new List<DalProfile>();
            foreach (var item in ormProfiles)
            {
                listOfProfiles.Add(item.ToDalProfile());
            }

            return listOfProfiles;
        }
    }
}
