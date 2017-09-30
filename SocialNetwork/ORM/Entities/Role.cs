using System.Collections.Generic;

namespace ORM.Entities
{
    /// <summary>
    /// ORM layout role class.
    /// </summary>
    public class Role
    {
        /// <summary>
        /// Default constructor of ORM role entity.
        /// </summary>
        public Role()
        {
            Users = new HashSet<User>();
        }

        /// <summary>
        /// Role id.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Role name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Users with current role. It needs for db creating.
        /// </summary>
        public virtual ICollection<User> Users { get; set; }

    }
}
