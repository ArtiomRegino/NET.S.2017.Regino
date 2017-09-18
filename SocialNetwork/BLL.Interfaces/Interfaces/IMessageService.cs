﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Interface.Entities;

namespace BLL.Interfaces.Interfaces
{
    public interface IMessageService : IService<BllMessage>
    {
        IEnumerable<BllMessage> GetAllChatsWith(int userId);
        void DeleteAllUserMessagesById(int id);
    }
}
