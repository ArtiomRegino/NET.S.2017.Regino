using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using DAL.Interface.DTO;
using DAL.Interface.Interfaces;
using DAL.Mappers;
using ORM.Entities;

namespace DAL.Concrete.Repositories
{
    public class MessageRepository: IMessageRepository
    {
        private readonly DbContext context;

        public MessageRepository(DbContext unitOfWork)
        {
            context = unitOfWork;
        }

        public void Create(DalMessage e)
        {
            var ormMessage = e.ToOrmMessage();
            context.Set<Message>().Add(ormMessage);
        }

        public void Delete(DalMessage e)
        {
            var message = context.Set<Message>().FirstOrDefault(m => m.Id == e.Id);

            context.Set<Message>().Attach(message);
            context.Set<Message>().Remove(message);
            context.Entry(message).State = EntityState.Deleted;
        }

        public IEnumerable<DalMessage> GetAll()
        {
            var result = context.Set<Message>().Select(m => m).ToList();
            return result.Select(m => m.ToDalMessage());
        }

        public DalMessage GetById(int? key)
        {
            var message = context.Set<Message>().Find(key);
            if (message == null)
                return null;
            return message.ToDalMessage();
        }

        public void Update(DalMessage e)
        {
            var ormMessage = e.ToOrmMessage();
            var message = context.Set<Message>().FirstOrDefault(m => m.Id == e.Id);
            if (message != null)
            {
                message.Text = ormMessage.Text;
            }
        }

        public List<DalMessage> GetMessages(int firstUserId, int secondUserId)
        {
            return GetAll().Where(m => (m.UserFromId == firstUserId && m.UserToId == secondUserId) ||
                                       (m.UserFromId == secondUserId && m.UserToId == firstUserId)).
                OrderBy(m => m.Date).ToList();
        }

        public void DeleteAllUserMessagesById(int id)
        {
            var messages = context.Set<Message>().Where(m => m.UserFromId == id || m.UserToId == id);
            foreach (var item in messages)
            {
                context.Set<Message>().Attach(item);
                context.Set<Message>().Remove(item);
                context.Entry(item).State = EntityState.Deleted;
            }
        }
    }
}
