using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Interface.DTO;
using ORM.Entities;

namespace DAL.Mappers
{
    public static class FriendshipMapper
    {
        public static DalFriendship ToDalFriendship(this Friendship ormFriendship)
        {
            if (ormFriendship == null) return null;

            var currentDalMessage = new DalFriendship()
            {
                Id = ormFriendship.Id,
                UserFromId = ormFriendship.UserFromId,
                UserToId = ormFriendship.UserToId,
                IsConfirmed = ormFriendship.IsConfirmed,
                RequestDate = ormFriendship.RequestDate
            };

            return currentDalMessage;
        }

        public static Friendship ToOrmFriendship(this DalFriendship dalFriendship)
        {
            if (dalFriendship == null) return null;

            var currentDalFriendship = new Friendship()
            {
                Id = dalFriendship.Id,
                UserFromId = dalFriendship.UserFromId,
                UserToId = dalFriendship.UserToId,
                IsConfirmed = dalFriendship.IsConfirmed,
                RequestDate = dalFriendship.RequestDate
            };

            return currentDalFriendship;
        }

        public static IEnumerable<DalFriendship> Map(this IQueryable<Friendship> ormFrendshipCollection)
        {
            if (ormFrendshipCollection == null) return null;

            var listOfFriendship = new List<DalFriendship>();
            foreach (var item in ormFrendshipCollection)
            {
                listOfFriendship.Add(item.ToDalFriendship());
            }

            return listOfFriendship;
        }

    }
}
