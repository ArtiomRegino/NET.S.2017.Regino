using DAL.Interface.Interfaces;

namespace DAL.Interface.DTO
{
    /// <summary>
    /// DAL layout user class.
    /// </summary>
    public class DalUser : IEntity
    {
        /// <summary>
        /// DalUser id.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// DalUser username.
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// DalUser e-mail.
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// DalUser password.
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// DalUser profile id.
        /// </summary>
        public int? ProfileId { get; set; }

        /// <summary>
        /// DalUser role id.
        /// </summary>
        public int RoleId { get; set; } 
        
        /// <summary>
        /// DalUser reference to profile.
        /// </summary>
        public DalProfile Profile { get; set; }
    }
}
