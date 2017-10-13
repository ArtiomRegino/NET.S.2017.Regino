using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using DAL.Interface.DTO;
using DAL.Interface.Interfaces;
using DAL.Mappers;
using ORM.Entities;

namespace DAL.Concrete.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly DbContext context;

        public UserRepository(DbContext context)
        {
            this.context = context;
        }

        public IEnumerable<DalUser> GetAll()
        {
            var result = context.Set<User>().Select(u => u).ToList();
            return result.Select(u => u.ToDalUser());
        }

        public DalUser GetById(int? key)
        {
            var result = context.Set<User>().Find(key);
            return result.ToDalUser();
        }

        public void Create(DalUser user)
        {
            context.Set<User>().Add(user.ToOrmUser());
            context.SaveChanges();
        }

        public void Delete(DalUser dalUser)
        {
            var ormUser = dalUser.ToOrmUser();
            var user = context.Set<User>().FirstOrDefault(u => u.Id == ormUser.Id);
            if (user == null)
                return;

            context.Set<User>().Attach(user);
            context.Set<User>().Remove(user);
            context.Entry(user).State = EntityState.Deleted;
        }

        public void Update(DalUser e)
        {
            if (e == null)
                return;

            var userToUpdate = context.Set<User>().FirstOrDefault(u => u.Id == e.Id);
            if (userToUpdate == null)
                return;

            context.Set<User>().Attach(userToUpdate);
            userToUpdate.RoleId = e.RoleId;
            userToUpdate.Email = e.Email;
            userToUpdate.Password = e.Password;
            context.Entry(userToUpdate).State = EntityState.Modified;
        }

        public DalUser GetUserByEmail(string email)
        {
            var user = context.Set<User>().FirstOrDefault(u => u.Email == email);
            return user?.ToDalUser();
        }

        public DalUser GetUserByUserName(string username)
        {
            var user = context.Set<User>().FirstOrDefault(u => u.UserName == username).ToDalUser();
            return user;
        }
    }
}
