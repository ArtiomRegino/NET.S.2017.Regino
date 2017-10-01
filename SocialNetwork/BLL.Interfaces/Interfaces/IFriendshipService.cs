using BLL.Interfaces.Entities;

namespace BLL.Interfaces.Interfaces
{
    public interface IFriendshipService : IService<BllFriendship>
    {
        bool? IsFriend (int curUser, int otherUser);
        void AddFriend (int userId, int otherUserId);
        void Confirm (int currentUser, int otherUser);
        void DeleteById(int curUserId, int otherUserId);
        void DeleteAllUserRelationById (int id);
    }
}
