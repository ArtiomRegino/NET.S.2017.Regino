using System.Data.Entity;
using ORM.Entities;

namespace ORM
{
    /// <summary>
    /// Service ORM layout class, DbContext inheritor
    /// </summary>
    public class SocialNetworkContext : DbContext
    {
        /// <summary>
        /// Creates context and starts initializer
        /// </summary>
        public SocialNetworkContext() : base("SocialNetworkContext")
        {
            Database.SetInitializer( new DropCreateDbInitializer());
        }

        /// <summary>
        /// Friendship collection
        /// </summary>
        public DbSet<Friendship> Friendships { get; set; }

        /// <summary>
        /// Messages collection
        /// </summary>
        public DbSet<Message> Messages { get; set; }

        /// <summary>
        /// Photos collection
        /// </summary>
        public DbSet<Photo> Photos { get; set; }

        /// <summary>
        /// Profiles collection
        /// </summary>
        public DbSet<Profile> Profiles { get; set; }

        /// <summary>
        /// Roles collection
        /// </summary>
        public DbSet<Role> Roles { get; set; }

        /// <summary>
        /// Users collection
        /// </summary>
        public DbSet<User> Users { get; set; }
    }
}
