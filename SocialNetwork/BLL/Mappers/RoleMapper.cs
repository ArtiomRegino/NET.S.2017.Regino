using System.Collections.Generic;
using System.Linq;
using BLL.Interfaces.Entities;
using DAL.Interface.DTO;

namespace BLL.Mappers
{
    public static class RoleMapper
    {
        public static BllRole ToBllRole(this DalRole dalRole)
        {
            if (dalRole == null) return null;
            var currentBllRole = new BllRole()
            {
                Id = dalRole.Id,
                Name = dalRole.Name
            };

            return currentBllRole;
        }

        public static DalRole ToDalRole(this BllRole bllRole)
        {
            if (bllRole == null) return null;
            var currentDalRole = new DalRole()
            {
                Id = bllRole.Id,
                Name = bllRole.Name
            };

            return currentDalRole;
        }

        public static IEnumerable<BllRole> Map(this IEnumerable<DalRole> dalRoles)
        {
            if (dalRoles == null) return null;

            return dalRoles.Select(item => item.ToBllRole()).ToList();
        }
    }
}
