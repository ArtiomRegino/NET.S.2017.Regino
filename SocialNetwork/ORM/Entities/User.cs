namespace ORM.Entities
{
    /// <summary>
    /// ORM layout user class.
    /// </summary>
    public class User
    {
        /// <summary>
        /// User id.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// User name.
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// User password.
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// User e-mail.
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Id of user profile.
        /// </summary>
        public int? ProfileId { get; set; }

        /// <summary>
        /// User profile. It needs for db creating.
        /// </summary>
        public virtual Profile Profile { get; set; }

        /// <summary>
        /// Id of user role.
        /// </summary>
        public int RoleId { get; set; }

        /// <summary>
        /// User role. It needs for db creating.
        /// </summary>
        public virtual Role Role { get; set; }
    }
}
