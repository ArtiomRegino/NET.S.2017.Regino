using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Interface.DTO;
using DAL.Interface.Interfaces;
using DAL.Mappers;
using ORM.Entities;

namespace DAL.Concrete.Repositories
{
    //Репозиторий — это коллекция.Коллекция, которая содержит сущности и может фильтровать и возвращать результат обратно в зависимости от требований вашего приложения. Где и как он хранит эти объекты является ДЕТАЛЬЮ РЕАЛИЗАЦИИ.

    public class UserRepository : IUserRepository
    {
        private readonly DbContext context;//обработать исключения в репозиториях

        public UserRepository(DbContext context)
        {
            this.context = context;
        }

        //DbSet представляет коллекцию всех сущностей указанного типа, которые содержатся в контексте или могут быть запрошены из базы данных. Объекты DbSet создаются из DbContext с помощью метода DbContext.Set.
        public IEnumerable<DalUser> GetAll()
        {
            var result = context.Set<User>().Select(u => u).ToList();// почему если возвращать из метода iquerable все падает
            return result.Select(u => u.ToDalUser());
        }

        public DalUser GetById(int key)
        {
            var result = context.Set<User>().Find(key);
            return result.ToDalUser();
        }

        public void Create(DalUser user)
        {
            context.Set<User>().Add(user.ToOrmUser());
            context.SaveChanges();
        }

        public void Delete(DalUser dalUser)//разобраться в удалении!
        {
            var ormUser = dalUser.ToOrmUser();
            var user = context.Set<User>().FirstOrDefault(u => u.Id == ormUser.Id);
            context.Set<User>().Attach(user);//как работает attach
            context.Set<User>().Remove(user);
            context.Entry(user).State = System.Data.Entity.EntityState.Deleted;
        }

        public void Update(DalUser e)
        {
            if (e != null)
            {
                var userToUpdate = context.Set<User>().FirstOrDefault(u => u.Id == e.Id);
                context.Set<User>().Attach(userToUpdate);
                userToUpdate.RoleId = e.RoleId;
                userToUpdate.Email = e.Email;
                userToUpdate.Password = e.Password;
                context.Entry(userToUpdate).State = System.Data.Entity.EntityState.Modified;
            }
        }

        public DalUser GetUserByEmail(string email)
        {
            var user = context.Set<User>().FirstOrDefault(u => u.Email == email);
            if (user == null)
                return null;
            return user.ToDalUser();
        }

        public DalUser GetUserByUserName(string username)
        {
            var user = context.Set<User>().FirstOrDefault(u => u.UserName == username).ToDalUser();
            if (user == null)
                return null;
            return user;
        }
    }
}
