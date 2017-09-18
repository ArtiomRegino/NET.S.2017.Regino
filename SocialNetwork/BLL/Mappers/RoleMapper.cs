using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Interface.Entities;
using DAL.Interface.DTO;

namespace BLL.Mappers
{
    public static class RoleMapper
    {
        public static BllRole ToBllRole(this DalRole dalRole)
        {
            if (dalRole == null) return null;
            BllRole currentBllRole = new BllRole()
            {
                Id = dalRole.Id,
                Name = dalRole.Name
            };

            return currentBllRole;
        }

        public static DalRole ToDalRole(this BllRole bllRole)
        {
            if (bllRole == null) return null;
            DalRole currentDalRole = new DalRole()
            {
                Id = bllRole.Id,
                Name = bllRole.Name
            };

            return currentDalRole;
        }

        public static IEnumerable<BllRole> Map(this IEnumerable<DalRole> dalRoles)
        {
            if (dalRoles == null) return null;

            var listOfRoles = new List<BllRole>();
            foreach (var item in dalRoles)
            {
                listOfRoles.Add(item.ToBllRole());
            }

            return listOfRoles;
        }
    }
}
