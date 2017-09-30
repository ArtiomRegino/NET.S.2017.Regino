using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace ORM.Entities
{
    /// <summary>
    /// ORM layout photo class.
    /// </summary>
    public class Photo
    {
        public Photo()
        {
            Date = DateTime.Now;
        }

        /// <summary>
        /// Photo id.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Data of photo.
        /// </summary>
        [Column(TypeName = "varbinary(MAX)")]
        public byte[] Data { get; set; }

        /// <summary>
        /// Mime type.
        /// </summary>
        public string MimeType { get; set; }

        /// <summary>
        /// Date of uploading.
        /// </summary>
        [Column(TypeName = "datetime2")]
        public DateTime Date { get; set; }

    }
}
