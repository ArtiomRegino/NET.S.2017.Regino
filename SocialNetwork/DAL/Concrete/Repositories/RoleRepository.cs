using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using DAL.Interface.DTO;
using DAL.Interface.Interfaces;
using DAL.Mappers;
using ORM.Entities;

namespace DAL.Concrete.Repositories
{
    public class RoleRepository: IRoleRepository
    {
        private readonly DbContext context;

        public RoleRepository(DbContext context)
        {
            this.context = context;
        }

        public IEnumerable<DalRole> GetAll()
        {
            var result = context.Set<Role>().Select(r => r).ToList();
            return result.Select(r => r.ToDalRole());
        }

        public DalRole GetById(int? key)
        {
            return context.Set<Role>().Find(key).ToDalRole();
        }

        public void Create(DalRole e)
        {
            context.Set<Role>().Add(e.ToOrmRole());
        }

        #region Not emplemented

        public void Delete(DalRole e)
        {
            throw new NotImplementedException();
        }

        public void Update(DalRole e)
        {
            throw new NotImplementedException();
        }
        
        #endregion
    }
}
