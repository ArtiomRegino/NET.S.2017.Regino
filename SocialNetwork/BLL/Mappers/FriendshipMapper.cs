using System.Collections.Generic;
using System.Linq;
using BLL.Interfaces.Entities;
using DAL.Interface.DTO;

namespace BLL.Mappers
{
    public static class FriendshipMapper
    {
        public static BllFriendship ToBllFriendship(this DalFriendship dalFriendship)
        {
            if (dalFriendship == null) return null;

            var currentBllFriendship = new BllFriendship()
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

            var currentDalMessage = new DalFriendship()
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

            return dalFrendshipCollection.Select(item => item.ToBllFriendship()).ToList();
        }
    }
}
