using System;
using System.Collections.Generic;
using System.Linq;
using BLL.Interfaces.Entities;
using BLL.Interfaces.Interfaces;
using BLL.Mappers;
using DAL.Interface.Interfaces;

namespace BLL.Servicies
{
    public class FriendshipService: IFriendshipService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IFriendshipRepository friendshipRepository;

        public FriendshipService(IUnitOfWork unitOfWork, IFriendshipRepository friendshipRepository)
        {
            this.unitOfWork = unitOfWork;
            this.friendshipRepository = friendshipRepository;
        }
        public BllFriendship GetById(int? id)
        {
            BllFriendship friendship = friendshipRepository.GetById(id).ToBllFriendship();
            unitOfWork.Commit();
            return friendship;
        }

        public IEnumerable<BllFriendship> GetAll()
        {
            IEnumerable<BllFriendship> friendships = friendshipRepository.GetAll().Map();
            unitOfWork.Commit();
            return friendships;
        }

        public void Create(BllFriendship item)
        {
            friendshipRepository.Create(item.ToDalFriendship());
            unitOfWork.Commit();
        }

        public void DeleteById(int curUserId, int otherUserId)
        {
            var friendship = friendshipRepository.GetAll().
                FirstOrDefault(fr => (fr.UserFromId == curUserId && fr.UserToId == otherUserId) ||
                                        (fr.UserToId == curUserId && fr.UserFromId == otherUserId));

            friendshipRepository.Delete(friendship);
            unitOfWork.Commit();
        }

        public void Delete(BllFriendship item)
        {
            friendshipRepository.Delete(item.ToDalFriendship());
            unitOfWork.Commit();
        }

        public void Update(BllFriendship item)
        {
            friendshipRepository.Update(item.ToDalFriendship());
            unitOfWork.Commit();
        }

        public bool? IsFriend(int curUserId, int otherUserId)
        {
            var friendship = friendshipRepository.GetAll()
                .FirstOrDefault(fr => (fr.UserFromId == curUserId && fr.UserToId == otherUserId &&
                                       (fr.IsConfirmed == true)) || (fr.UserToId == curUserId 
                                      && fr.UserFromId == otherUserId && (fr.IsConfirmed == true)));
            unitOfWork.Commit();
            if (friendship == null) return null;
            return friendship.IsConfirmed == true;
        }

        public void AddFriend(int userFromId, int userToId)
        {
            var friendship = new BllFriendship
            {
                IsConfirmed = false,
                UserFromId = userFromId,
                UserToId = userToId,
                RequestDate = DateTime.Now
            };

            Create(friendship);
            unitOfWork.Commit();
        }

        public void Confirm(int curUserId, int otherUserId)
        {
            var friendship = friendshipRepository.GetAll().
                FirstOrDefault(fr => (fr.UserFromId == curUserId && fr.UserToId == otherUserId) ||
                (fr.UserToId == curUserId && fr.UserFromId == otherUserId));
            friendship.IsConfirmed = true;

            friendshipRepository.Update(friendship);
            unitOfWork.Commit();
        }

        public void DeleteAllUserRelationById(int id)
        {
            friendshipRepository.DeleteAllUserRelationById(id);
            unitOfWork.Commit();
        }
    }
}
