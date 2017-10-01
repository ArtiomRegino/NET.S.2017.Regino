namespace BLL.Interfaces.Entities
{
    /// <summary>
    /// BLL layout user class.
    /// </summary>
    public class BllUser
    {
        /// <summary>
        /// BllUser id.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// BllUser username.
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// BllUser e-mail.
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// BllUser password.
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// BllUser profile id.
        /// </summary>
        public int? ProfileId { get; set; }

        /// <summary>
        /// BllUser role id.
        /// </summary>
        public int RoleId { get; set; }

        /// <summary>
        /// BllUser reference to profile.
        /// </summary>
        public BllProfile Profile { get; set; }
    }
}
