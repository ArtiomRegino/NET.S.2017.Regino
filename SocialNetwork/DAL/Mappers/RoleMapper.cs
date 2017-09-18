using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Interface.DTO;
using ORM.Entities;

namespace DAL.Mappers
{
    public static class RoleMapper
    {
        public static DalRole ToDalRole(this Role ormRole)
        {
            if (ormRole == null) return null;
            DalRole currentDalRole = new DalRole()
            {
                Id = ormRole.Id,
                Name = ormRole.Name
            };

            return currentDalRole;
        }

        public static Role ToOrmRole(this DalRole dalRole)
        {
            if (dalRole == null) return null;
            Role currentOrmRole = new Role()
            {
                Id = dalRole.Id,
                Name = dalRole.Name
            };

            return currentOrmRole;
        }

        public static IEnumerable<DalRole> Map(this IQueryable<Role> ormRoles)
        {
            if (ormRoles == null) return null;

            var dalRoles = new List<DalRole>();
            foreach (var item in ormRoles)
            {
                dalRoles.Add(item.ToDalRole());
            }

            return dalRoles;
        }
    }
}
