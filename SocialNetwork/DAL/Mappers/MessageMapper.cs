using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Interface.DTO;
using ORM.Entities;

namespace DAL.Mappers
{
    public static class MessageMapper
    {
        public static DalMessage ToDalMessage(this Message ormMessage)
        {
            if (ormMessage == null) return null;

            DalMessage currentDalMessage = new DalMessage()
            {
                Id = ormMessage.Id,
                Date = ormMessage.Date,
                Text = ormMessage.Text,
                UserFromId = ormMessage.UserFromId,
                UserToId = ormMessage.UserToId,
                UserFrom = ormMessage.UserFrom.ToDalProfile(),
                UserTo = ormMessage.UserTo.ToDalProfile()
            };

            return currentDalMessage;
        }

        public static Message ToOrmMessage(this DalMessage dalMessage)
        {
            if (dalMessage == null) return null;

            Message ormMessage = new Message()
            {
                Id = dalMessage.Id,
                Date = dalMessage.Date,
                Text = dalMessage.Text,
                UserFromId = dalMessage.UserFromId,
                UserToId = dalMessage.UserToId
            };

            return ormMessage;
        }

        public static IEnumerable<DalMessage> Map(this IQueryable<Message> ormMessages)
        {
            if (ormMessages == null) return null;

            var listOfMessages = new List<DalMessage>();
            foreach (var item in ormMessages)
            {
                listOfMessages.Add(item.ToDalMessage());
            }

            return listOfMessages;
        }
    }
}
