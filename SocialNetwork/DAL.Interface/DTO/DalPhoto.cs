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
        /// DalPhoto data.
        /// </summary>
        public byte[] Data { get; set; }

        /// <summary>
        /// Mime type of DalPhoto.
        /// </summary>
        public string MimeType { get; set; }

        /// <summary>
        /// Date of sending.
        /// </summary>
        public DateTime Date { get; set; }
    }
}
