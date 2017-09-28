using System.Data.Entity;
using ORM.Entities;

namespace ORM
{
    public class SocialNetworkContext : DbContext
    {
        public SocialNetworkContext() : base("SocialNetworkContext")
        {
            Database.SetInitializer( new DropCreateDbInitializer());
        }

        public DbSet<Friendship> Friendships { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<Photo> Photos { get; set; }
        public DbSet<Profile> Profiles { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
