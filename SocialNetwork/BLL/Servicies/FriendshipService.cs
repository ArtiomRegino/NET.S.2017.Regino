using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Interface.Entities;
using BLL.Interfaces.Interfaces;
using BLL.Mappers;
using DAL.Interface.Interfaces;

namespace BLL.Servicies
{
    public class FriendshipService: IFriendshipService //реализовать методы
    {
        private IUnitOfWork unitOfWork;
        private IFriendshipRepository friendshipRepository;

        public FriendshipService(IUnitOfWork unitOfWork, IFriendshipRepository friendshipRepository)
        {
            this.unitOfWork = unitOfWork;
            this.friendshipRepository = friendshipRepository;
        }
        public BllFriendship GetById(int id)
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

        public bool IsFriend(int curUser, int otherUser)
        {
            throw new NotImplementedException();
        }

        public void AddFriend(int userId, int otherUserId)
        {
            throw new NotImplementedException();
        }

        public bool IsRequested(int currentUser, int otherUser)
        {
            throw new NotImplementedException();
        }

        public void DeleteAllUserRelationById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
