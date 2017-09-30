using System;
using DAL.Interface.Interfaces;

namespace DAL.Interface.DTO
{
    /// <summary>
    /// DAL layout friendship class.
    /// </summary>
    public class DalFriendship : IEntity
    {

        /// <summary>
        /// DalFriendship id.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// DalFriendship date of request.
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
