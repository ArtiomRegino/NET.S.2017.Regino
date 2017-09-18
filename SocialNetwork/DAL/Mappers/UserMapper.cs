using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Interface.DTO;
using ORM.Entities;

namespace DAL.Mappers
{
    public static class UserMapper
    {
        public static DalUser ToDalUser(this User ormUser)
        {
            if (ormUser == null) return null;
            DalUser currentDalUser = new DalUser()
            {
                Id = ormUser.Id,
                Email = ormUser.Email,
                Password = ormUser.Password,
                Profile = ormUser.Profile.ToDalProfile(),
                UserName = ormUser.UserName,
                RoleId = ormUser.RoleId,
                ProfileId = ormUser.ProfileId
            };

            return currentDalUser;
        }

        public static User ToOrmUser(this DalUser dalUser)
        {
            if (dalUser == null) return null;
            User currentOrmUser = new User()
            {
                Id = dalUser.Id,
                Email = dalUser.Email,
                Password = dalUser.Password,
                Profile = dalUser.Profile.ToOrmProfile(),
                UserName = dalUser.UserName,
                RoleId = dalUser.RoleId,
                ProfileId = dalUser.ProfileId
            };

            return currentOrmUser;
        }

        public static IEnumerable<DalUser> Map(this IQueryable<User> ormUsers)
        {
            var dalUsersList = new List<DalUser>();
            foreach (var item in ormUsers)
            {
                dalUsersList.Add(item.ToDalUser());
            }

            return dalUsersList;
        }
    }
}
