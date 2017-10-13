using System.Collections.Generic;
using System.Linq;
using BLL.Interfaces.Entities;
using BLL.Interfaces.Interfaces;
using BLL.Mappers;
using DAL.Interface.Interfaces;

namespace BLL.Servicies
{
    public class MessageService: IMessageService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMessageRepository messageRepository;

        public MessageService(IUnitOfWork unitOfWork, IMessageRepository messageRepository)
        {
            this.unitOfWork = unitOfWork;
            this.messageRepository = messageRepository;

        }

        public BllMessage GetById(int? id)
        {
            BllMessage message = messageRepository.GetById(id).ToBllMessage();
            unitOfWork.Commit();

            return message;
        }

        public IEnumerable<BllMessage> GetAll()
        {
            IEnumerable<BllMessage> messages = messageRepository.GetAll().Map();
            unitOfWork.Commit();

            return messages;
        }

        public void Create(BllMessage item)
        {
            messageRepository.Create(item.ToDalMessage());
            unitOfWork.Commit();
        }

        public void Delete(BllMessage item)
        {
            messageRepository.Delete(item.ToDalMessage());
            unitOfWork.Commit();
        }

        public void Update(BllMessage item)
        {
            messageRepository.Update(item.ToDalMessage());
            unitOfWork.Commit();
        }

        public IEnumerable<BllMessage> GetLastMessagesOfTo(int userId)
        {
            var messages = messageRepository.GetAll().
                Where(m => m.UserFromId == userId || m.UserToId == userId);
            var idsOfinterlocutors = new HashSet<int?>();

            foreach (var item in messages)
            {
                idsOfinterlocutors.Add(item.UserFromId == userId ? item.UserToId : item.UserFromId);
            }

            var lastMessages = idsOfinterlocutors.
                Select(item => messages.Last(m => (m.UserFromId == item && m.UserToId == userId)
                ||(m.UserToId == item && m.UserFromId == userId)).ToBllMessage()).ToList();

            return lastMessages;
        }

        public void DeleteAllUserMessagesById(int id)
        {
            messageRepository.DeleteAllUserMessagesById(id);
            unitOfWork.Commit();
        }
    }
}
