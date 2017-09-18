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

            DalProfile currentDalProfile = new DalProfile()
            {
                Id = ormProfile.Id,
                BirthDate = ormProfile.BirthDate,
                City = ormProfile.City,
                FirstName = ormProfile.FirstName,
                LastName = ormProfile.LastName,
                Photo = ormProfile.Photo.ToDalPhoto(),
                PhotoId = ormProfile.PhotoId,
                UserName = ormProfile.UserName,
                AboutMe = ormProfile.AboutMe,
                ContactPhone = ormProfile.ContactPhone,
                Gender = ormProfile.Gender
            };
            //нужно ли мапить фото и айдишник фото?
            return currentDalProfile;
        }

        public static Profile ToOrmProfile(this DalProfile dalProfile)
        {
            if (dalProfile == null) return null;

            Profile currentDalProfile = new Profile()
            {
                Id = dalProfile.Id,
                BirthDate = dalProfile.BirthDate,
                City = dalProfile.City,
                FirstName = dalProfile.FirstName,
                LastName = dalProfile.LastName,
                Photo = dalProfile.Photo.ToOrmPhoto(),
                PhotoId = dalProfile.PhotoId,
                UserName = dalProfile.UserName,
                AboutMe = dalProfile.AboutMe,
                ContactPhone = dalProfile.ContactPhone,
                Gender = dalProfile.Gender
            };
            //нужно ли мапить фото и айдишник фото?
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
