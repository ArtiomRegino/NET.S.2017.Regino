using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using DAL.Interface.DTO;
using DAL.Interface.Interfaces;
using DAL.Mappers;
using ORM.Entities;

namespace DAL.Concrete.Repositories
{
    public class FriendshipRepository: IFriendshipRepository
    {
        private readonly DbContext context;

        public FriendshipRepository(DbContext unitOfWork)
        {
            context = unitOfWork;
        }
        public void Create(DalFriendship e)
        {
            context.Set<Friendship>().Add(e.ToOrmFriendship());
        }

        public void Delete(DalFriendship dalFriendship)
        {
            if (dalFriendship == null)
                return;

            var ormFriendship = dalFriendship.ToOrmFriendship();
            var friendship = context.Set<Friendship>()
                .FirstOrDefault(f => f.Id == ormFriendship.Id);

            if (friendship == null)
                return;

            context.Set<Friendship>().Attach(friendship);
            context.Set<Friendship>().Remove(friendship);
            context.Entry(friendship).State = EntityState.Deleted;
        }

        public IEnumerable<DalFriendship> GetAll()
        {
            var result = context.Set<Friendship>().Select(m => m).ToList();
            return result.Select(u => u.ToDalFriendship());
        }

        public DalFriendship GetById(int? key)
        {
            var friendship = context.Set<Friendship>().Find(key);
            return friendship?.ToDalFriendship();
        }

        public void Update(DalFriendship dalFriendship)
        {
            if (dalFriendship != null)
            {
                context.Set<Friendship>()
                    .AddOrUpdate(dalFriendship.ToOrmFriendship());
            }
        }

        public void DeleteAllUserRelationById(int id)
        {
            var friendships = context.Set<Friendship>().Where(f => f.UserFromId == id || f.UserToId == id);
            foreach (var item in friendships)
            {
                context.Set<Friendship>().Attach(item);
                context.Set<Friendship>().Remove(item);
                context.Entry(item).State = EntityState.Deleted;
            }
        }
    }
}
