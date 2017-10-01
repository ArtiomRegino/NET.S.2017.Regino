using System.Collections.Generic;
using BLL.Interfaces.Entities;

namespace BLL.Interfaces.Interfaces
{
    public interface IMessageService : IService<BllMessage>
    {
        IEnumerable<BllMessage> GetLastMessagesOfTo(int userId);
        void DeleteAllUserMessagesById(int id);
    }
}
