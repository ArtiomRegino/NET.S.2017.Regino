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
    public class ProfileService : IProfileService//нет поиска!
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

        public IEnumerable<BllProfile> Search(BllProfile profile)
        {
            throw new NotImplementedException();
        }

        public BllProfile GetByUserEmail(string email)
        {
            BllProfile profile = profileRepository.GetByUserEmail(email).ToBllProfile();
            unitOfWork.Commit();
            return profile;
        }
    }
}
