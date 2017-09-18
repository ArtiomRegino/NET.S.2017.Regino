using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Interface.Entities;
using DAL.Interface.DTO;

namespace BLL.Mappers
{
    public static class FriendshipMapper
    {
        public static BllFriendship ToBllFriendship(this DalFriendship dalFriendship)
        {
            if (dalFriendship == null) return null;

            BllFriendship currentBllFriendship = new BllFriendship()
            {
                Id = dalFriendship.Id,
                UserFromId = dalFriendship.UserFromId,
                UserToId = dalFriendship.UserToId,
                IsConfirmed = dalFriendship.IsConfirmed,
                RequestDate = dalFriendship.RequestDate
            };

            return currentBllFriendship;
        }

        public static DalFriendship ToDalFriendship(this BllFriendship bllFriendship)
        {
            if (bllFriendship == null) return null;

            DalFriendship currentDalMessage = new DalFriendship()
            {
                Id = bllFriendship.Id,
                UserFromId = bllFriendship.UserFromId,
                UserToId = bllFriendship.UserToId,
                IsConfirmed = bllFriendship.IsConfirmed,
                RequestDate = bllFriendship.RequestDate
            };

            return currentDalMessage;
        }

        public static IEnumerable<BllFriendship> Map(this IEnumerable<DalFriendship> dalFrendshipCollection)
        {
            if (dalFrendshipCollection == null) return null;

            var listOfFriendship = new List<BllFriendship>();
            foreach (var item in dalFrendshipCollection)
            {
                listOfFriendship.Add(item.ToBllFriendship());
            }

            return listOfFriendship;
        }
    }
}
