using DAL.Interface.Interfaces;
using System;

namespace DAL.Interface.DTO
{
    /// <summary>
    /// DAL layout message class.
    /// </summary>
    public class DalMessage : IEntity
    {
        /// <summary>
        /// DalMessage id.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Text of DalMessage.
        /// </summary>
        public string Text { get; set; }

        /// <summary>
        /// DalMessage date of sending.
        /// </summary>
        public DateTime? Date { get; set; }

        /// <summary>
        /// DalMessage was sending by user with UserFromId.
        /// </summary>
        public int? UserFromId { get; set; }

        /// <summary>
        /// DalMessage was sending to user with UserToId.
        /// </summary>
        public int? UserToId { get; set; }

        /// <summary>
        /// Reference to user profile.
        /// </summary>
        public DalProfile UserTo { get; set; }

        /// <summary>
        /// Reference to user profile.
        /// </summary>
        public DalProfile UserFrom { get; set; }
    }
}
