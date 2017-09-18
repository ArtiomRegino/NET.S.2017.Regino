using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Interface.DTO;
using BLL.Interface.Entities;

namespace BLL.Mappers
{
    public static class UserMapper
    {
        public static BllUser ToBllUser(this DalUser dalUser)
        {
            if (dalUser == null) return null;
            BllUser currentBllUser = new BllUser()
            {
                Id = dalUser.Id,
                Email = dalUser.Email,
                Password = dalUser.Password,
                Profile = dalUser.Profile.ToBllProfile(),
                UserName = dalUser.UserName,
                RoleId = dalUser.RoleId,
                ProfileId = dalUser.ProfileId
            };

            return currentBllUser;
        }

        public static DalUser ToDalUser(this BllUser bllUser)
        {
            if (bllUser == null) return null;
            DalUser currentDalUser = new DalUser()
            {
                Id = bllUser.Id,
                Email = bllUser.Email,
                Password = bllUser.Password,
                Profile = bllUser.Profile.ToDalProfile(),
                UserName = bllUser.UserName,
                RoleId = bllUser.RoleId,
                ProfileId = bllUser.ProfileId
            };
            return currentDalUser;
        }

        public static IEnumerable<BllUser> Map(this IEnumerable<DalUser> dalUsers)
        {
            var bllUsersList = new List<BllUser>();
            foreach (var item in dalUsers)
            {
                bllUsersList.Add(item.ToBllUser());
            }

            return bllUsersList;
        }
    }
}
