using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Interface.Entities;
using BLL.Interfaces.Interfaces;
using BLL.Mappers;
using DAL.Interface.DTO;
using DAL.Interface.Interfaces;

namespace BLL.Servicies
{
    public class MessageService: IMessageService//проверить налы во всех репозиториях + 2 метода
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMessageRepository messageRepository;


        public MessageService(IUnitOfWork unitOfWork, IMessageRepository messageRepository)
        {
            this.unitOfWork = unitOfWork;
            this.messageRepository = messageRepository;

        }
        public BllMessage GetById(int id)
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

        public IEnumerable<BllMessage> GetAllChatsWith(int userId)
        {
            throw new NotImplementedException();
        }

        public void DeleteAllUserMessagesById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
