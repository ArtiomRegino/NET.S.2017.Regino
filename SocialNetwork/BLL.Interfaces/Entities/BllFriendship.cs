using System;

namespace BLL.Interfaces.Entities
{
    /// <summary>
    /// BLL layout friendship class.
    /// </summary>
    public class BllFriendship
    {
        /// <summary>
        /// BllFriendship id.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// BllFriendship date of request.
        /// </summary>
        public DateTime? RequestDate { get; set; }

        /// <summary>
        /// Request was sending by user with UserFromId.
        /// </summary>
        public int? UserFromId { get; set; }

        /// <summary>
        /// Request was sending to user with UserToId.
        /// </summary>
        public int? UserToId { get; set; }

        /// <summary>
        /// Request was confirmed by user with UserToId.
        /// </summary>
        public bool? IsConfirmed { get; set; }
    }
}
