using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using DAL.Interface.DTO;
using DAL.Interface.Interfaces;
using DAL.Mappers;
using ORM.Entities;

namespace DAL.Concrete.Repositories
{
    public class ProfileRepository: IProfileRepository
    {
        private readonly DbContext context;

        public ProfileRepository(DbContext unitOfWork)
        {
            context = unitOfWork;
        }
        public void Create(DalProfile dalProfile)
        {
            context.Set<Profile>().Add(dalProfile.ToOrmProfile());
        }

        public void Delete(DalProfile dalProfile)
        {
            var userProfile = context.Set<Profile>()
                .FirstOrDefault(p => p.Id == dalProfile.Id);

            if (userProfile == null)
                return;

            context.Set<Profile>().Attach(userProfile);
            context.Set<Profile>().Remove(userProfile);
            context.Entry(userProfile).State = EntityState.Deleted;
        }

        public IEnumerable<DalProfile> GetAll()
        {
            var result = context.Set<Profile>().Select(p => p).ToList();
            return result.Select(p => p.ToDalProfile());
        }

        public DalProfile GetById(int? key)
        {
            var profile = context.Set<Profile>().Find(key);
            return profile?.ToDalProfile();
        }

        public void AddPhoto(DalPhoto item)
        {
            var profile = context.Set<Profile>().FirstOrDefault(p => p.Id == item.ProfileId);
            profile.Photos.Add(item.ToOrmPhoto());

            context.Set<Profile>().Attach(profile);

            context.Entry(profile).State = EntityState.Modified;
        }

        public void Update(DalProfile dalProfile)
        {
            if (dalProfile == null)
                return;

            var profile = context.Set<Profile>()
                .FirstOrDefault(p => p.Id == dalProfile.Id);

            if (profile == null)
                return;

            context.Set<Profile>().Attach(profile);

            profile.FirstName = dalProfile.FirstName ?? profile.FirstName;
            profile.LastName = dalProfile.LastName ?? profile.LastName;
            profile.BirthDate = dalProfile.BirthDate ?? profile.BirthDate;
            profile.AboutMe = dalProfile.AboutMe ?? profile.AboutMe;
            profile.ContactPhone = dalProfile.ContactPhone ?? profile.ContactPhone;
            profile.City = dalProfile.City ?? profile.City;
            profile.Gender = dalProfile.Gender ?? profile.Gender;
            profile.PhotoId = dalProfile.PhotoId ?? profile.PhotoId;

            context.Entry(profile).State = EntityState.Modified;
        }

        public DalProfile GetByUserEmail(string email)
        {
            if (email == null)
                return null;

            var user = context.Set<User>()
                .Include(u => u.Profile)
                .FirstOrDefault(u => u.Email == email);

            return user?.Profile.ToDalProfile();
        }
    }
}
