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
    public class RoleService : IRoleService
    {
        private IUnitOfWork unitOfWork;
        private IRoleRepository roleRepository;

        public RoleService(IUnitOfWork unitOfWork, IRoleRepository roleRepository)
        {
            this.unitOfWork = unitOfWork;
            this.roleRepository = roleRepository;
        }

        public BllRole GetById(int id)
        {
            BllRole role = roleRepository.GetById(id).ToBllRole();
            unitOfWork.Commit();
            return role;
        }

        public IEnumerable<BllRole> GetAll()
        {
            IEnumerable<BllRole> roles = roleRepository.GetAll().Map();
            unitOfWork.Commit();
            return roles;
        }

        public void Create(BllRole item)
        {
            roleRepository.Create(item.ToDalRole());
            unitOfWork.Commit();
        }

        public void Delete(BllRole item)
        {
            roleRepository.Delete(item.ToDalRole());
            unitOfWork.Commit();
        }

        public void Update(BllRole item)
        {
            roleRepository.Update(item.ToDalRole());
            unitOfWork.Commit();
        }
    }
}
