using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Interface.DTO;

namespace DAL.Interface.Interfaces
{
    public interface IMessageRepository: IRepository<DalMessage>
    {
        List<DalMessage> GetMessages(int UserFrom, int UserTo);
        void DeleteAllUserMessagesById(int id);
    }
}
