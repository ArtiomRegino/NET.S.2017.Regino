using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Interface.Entities;

namespace BLL.Interfaces.Interfaces
{
    public interface IFriendshipService : IService<BllFriendship>
    {
        bool? IsFriend (int curUser, int otherUser);
        void AddFriend (int userId, int otherUserId);
        bool IsRequested (int currentUser, int otherUser);
        void Confirm (int currentUser, int otherUser);
        void DeleteAllUserRelationById (int id);
    }
}
