using System;

namespace BLL.Interfaces.Entities
{
    /// <summary>
    /// BLL layout photo class.
    /// </summary>
    public class BllPhoto
    {
        /// <summary>
        /// BllPhoto id.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Bll fullsize image.
        /// </summary>
        public byte[] BigImage { get; set; }

        /// <summary>
        /// Bll small image.
        /// </summary>
        public byte[] SmallImage { get; set; }

        /// <summary>
        /// Mime type of BllPhoto.
        /// </summary>
        public string MimeType { get; set; }

        /// <summary>
        /// Date of sending.
        /// </summary>
        public DateTime Date { get; set; }

        /// <summary>
        /// Bll description.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// BllPhoto is avatar.
        /// </summary>
        public bool IsAvatar { get; set; }

        /// <summary>
        /// Photo belongs to the user.
        /// </summary>
        public int ProfileId { get; set; }

        /// <summary>
        /// BllPhoto reference to profile.
        /// </summary>
        public BllProfile Profile { get; set; }
    }
}
