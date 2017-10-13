using DAL.Interface.Interfaces;
using System;

namespace DAL.Interface.DTO
{
    /// <summary>
    /// DAL layout photo class.
    /// </summary>
    public class DalPhoto : IEntity
    {
        /// <summary>
        /// DalPhoto id.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Dall fullsize image.
        /// </summary>
        public byte[] BigImage { get; set; }

        /// <summary>
        /// Dal small image.
        /// </summary>
        public byte[] SmallImage { get; set; }

        /// <summary>
        /// Mime type of DalPhoto.
        /// </summary>
        public string MimeType { get; set; }

        /// <summary>
        /// Date of sending.
        /// </summary>
        public DateTime Date { get; set; }

        /// <summary>
        /// Dal description.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// DalPhoto is avatar.
        /// </summary>
        public bool IsAvatar { get; set; }

        /// <summary>
        /// DalPhoto belongs to the user.
        /// </summary>
        public int ProfileId { get; set; }

        /// <summary>
        /// DalPhoto reference to profile.
        /// </summary>
        public DalProfile Profile { get; set; }
    }
}
