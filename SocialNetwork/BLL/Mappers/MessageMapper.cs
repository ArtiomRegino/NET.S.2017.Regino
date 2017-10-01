using System.Collections.Generic;
using System.Linq;
using BLL.Interfaces.Entities;
using DAL.Interface.DTO;

namespace BLL.Mappers
{
    public static class MessageMapper
    {
        public static BllMessage ToBllMessage(this DalMessage dalMessage)
        {
            if (dalMessage == null) return null;

            BllMessage currentBllMessage = new BllMessage()
            {
                Id = dalMessage.Id,
                Date = dalMessage.Date,
                Text = dalMessage.Text,
                UserFromId = dalMessage.UserFromId,
                UserToId = dalMessage.UserToId,
                UserFrom = dalMessage.UserFrom.ToBllProfile(),
                UserTo = dalMessage.UserTo.ToBllProfile()
            };

            return currentBllMessage;
        }

        public static DalMessage ToDalMessage(this BllMessage bllMessage)
        {
            if (bllMessage == null) return null;

            DalMessage dalMessage = new DalMessage()
            {
                Id = bllMessage.Id,
                Date = bllMessage.Date,
                Text = bllMessage.Text,
                UserFromId = bllMessage.UserFromId,
                UserToId = bllMessage.UserToId
            };

            return dalMessage;
        }

        public static IEnumerable<BllMessage> Map(this IEnumerable<DalMessage> dalMessages)
        {
            if (dalMessages == null) return null;

            return dalMessages.Select(item => item.ToBllMessage()).ToList();
        }
    }
}
