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
    public class UserService : IUserService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IUserRepository userRepository;

        public UserService(IUnitOfWork unitOfWork, IUserRepository userRepository)
        {
            this.unitOfWork = unitOfWork;
            this.userRepository = userRepository;
        }

        public BllUser GetById(int id)
        {
            BllUser user = userRepository.GetById(id).ToBllUser();
            unitOfWork.Commit();
            return user;
        }

        public IEnumerable<BllUser> GetAll()
        {
            IEnumerable<BllUser> users = userRepository.GetAll().Map();
            unitOfWork.Commit();
            return users;
        }

        public void Create(BllUser item)
        {
            userRepository.Create(item.ToDalUser());
            unitOfWork.Commit();
        }

        public void Delete(BllUser item)
        {
            userRepository.Delete(item.ToDalUser());
            unitOfWork.Commit();
        }

        public void Update(BllUser item)
        {
            userRepository.Update(item.ToDalUser());
            unitOfWork.Commit();
        }

        public BllUser GetUserByEmail(string email)
        {
            BllUser user = userRepository.GetUserByEmail(email).ToBllUser();
            unitOfWork.Commit();
            return user;
        }

        public BllUser GetUserByUserName(string username)
        {
            BllUser user = userRepository.GetUserByUserName(username).ToBllUser();
            unitOfWork.Commit();
            return user;
        }
    }
}
