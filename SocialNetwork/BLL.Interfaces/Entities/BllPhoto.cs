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
        /// BllPhoto data.
        /// </summary>
        public byte[] Data { get; set; }

        /// <summary>
        /// Mime type of BllPhoto.
        /// </summary>
        public string MimeType { get; set; }

        /// <summary>
        /// Date of sending.
        /// </summary>
        public DateTime Date { get; set; }
    }
}
