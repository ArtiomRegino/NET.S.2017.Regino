using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Interface.Entities;
using BLL.Interfaces.Interfaces;
using BLL.Mappers;
using DAL.Interface.Interfaces;

namespace BLL.Servicies
{
    public class ProfileService : IProfileService
    {
        private IUnitOfWork unitOfWork;
        private IProfileRepository profileRepository;

        public ProfileService(IUnitOfWork unitOfWork, IProfileRepository profileRepository)
        {
            this.unitOfWork = unitOfWork;
            this.profileRepository = profileRepository;
        }

        public BllProfile GetById(int id)
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

        public IEnumerable<BllProfile> FullSearch(BllProfile profile)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<BllProfile> FastSearch(string names)
        {
            var arrayOfNames = names.Split(' ');

            if (arrayOfNames.Length > 1)
            {
                string firstPart = arrayOfNames[0].ToLower();
                string secondPart = arrayOfNames[1].ToLower();

                var profiles = profileRepository.GetAll()
                    .Where(p => p.FirstName.ToLower() == firstPart ||
                                p.FirstName.ToLower() == secondPart || p.LastName.ToLower() == firstPart ||
                                p.LastName.ToLower() == secondPart).Distinct().Map();

                return profiles;
            }

            string first = arrayOfNames[0].ToLower();
            var profile = profileRepository.GetAll()
                .Where(p => p.FirstName.ToLower() == first || p.LastName.ToLower() == first).Distinct().Map();

            return profile;
        }

        public BllProfile GetByUserEmail(string email)
        {
            BllProfile profile = profileRepository.GetByUserEmail(email).ToBllProfile();
            unitOfWork.Commit();
            return profile;
        }
    }
}
