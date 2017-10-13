using System;
using System.Collections.Generic;
using System.Linq;
using BLL.Interfaces.Entities;
using BLL.Interfaces.Interfaces;
using BLL.Mappers;
using DAL.Interface.Interfaces;

namespace BLL.Servicies
{
    public class ProfileService : IProfileService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IProfileRepository profileRepository;

        public ProfileService(IUnitOfWork unitOfWork, IProfileRepository profileRepository)
        {
            this.unitOfWork = unitOfWork;
            this.profileRepository = profileRepository;
        }

        public BllProfile GetById(int? id)
        {
            BllProfile profile = profileRepository.GetById(id).ToBllProfile();
            unitOfWork.Commit();

            return profile;
        }

        public IEnumerable<BllProfile> GetAll()
        {
            IEnumerable<BllProfile> profiles = profileRepository.GetAll().Map();
            unitOfWork.Commit();

            return profiles;
        }

        public void Create(BllProfile item)
        {
            profileRepository.Create(item.ToDalProfile());
            unitOfWork.Commit();
        }

        public void AddPhoto(BllPhoto item)
        {
            profileRepository.AddPhoto(item.ToDalPhoto());

            unitOfWork.Commit();
        }

        public void Delete(BllProfile item)
        {
            profileRepository.Delete(item.ToDalProfile());
            unitOfWork.Commit();
        }

        public void Update(BllProfile item)
        {
            profileRepository.Update(item.ToDalProfile());
            unitOfWork.Commit();
        }

        public void Update(IEnumerable<BllProfile> items)
        {
            foreach (var item in items)
            {
                profileRepository.Update(item.ToDalProfile());
            }
            
            unitOfWork.Commit();
        }

        public IEnumerable<BllProfile> FullSearch(BllProfile profile)
        {
            var profiles = profileRepository.GetAll();

            if (profile.Gender != null)
            {
                profiles = profiles.Where(p => p.Gender == profile.Gender);
            }
            if (profile.FirstName != null)
            {
                profiles = profiles.Where(p =>
                string.Equals(p.FirstName, profile.FirstName, StringComparison.CurrentCultureIgnoreCase));
            }
            if (profile.LastName != null)
            {
                profiles = profiles.Where(p =>
                string.Equals(p.LastName, profile.LastName, StringComparison.CurrentCultureIgnoreCase));
            }
            if (profile.City != null)
            {
                profiles = profiles.Where(p =>
                string.Equals(p.City, profile.City, StringComparison.CurrentCultureIgnoreCase));
            }
            if (profile.BirthDate != null)
            {
                profiles = profiles.Where(p => p.BirthDate == profile.BirthDate);
            }
            unitOfWork.Commit();

            return profiles.Map();
        }

        public IEnumerable<BllProfile> FastSearch(string names)
        {
            var arrayOfNames = names.Split(' ');

            if (arrayOfNames.Length > 1)
            {
                string firstPart = arrayOfNames[0].ToLower();
                string secondPart = arrayOfNames[1].ToLower();

                var profiles = profileRepository.GetAll()
                    .Where(p => p.FirstName.ToLower() == firstPart
                                || p.FirstName.ToLower() == secondPart 
                                || p.LastName.ToLower() == firstPart
                                || p.LastName.ToLower() == secondPart).Distinct().Map();

                return profiles;
            }

            string first = arrayOfNames[0].ToLower();
            var profile = profileRepository.GetAll()
                .Where(p => p.FirstName.ToLower() == first
                || p.LastName.ToLower() == first).Distinct().Map();

            unitOfWork.Commit();

            return profile;
        }

        public BllProfile GetByUserEmail(string email)
        {
            var profile = profileRepository.GetByUserEmail(email).ToBllProfile();
            unitOfWork.Commit();

            return profile;
        }
    }
}
