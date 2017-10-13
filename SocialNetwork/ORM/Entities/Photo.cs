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
        /// Full image.
        /// </summary>
        [Column(TypeName = "varbinary(MAX)")]
        public byte[] BigImage { get; set; }

        /// <summary>
        /// Small image.
        /// </summary>
        [Column(TypeName = "varbinary(MAX)")]
        public byte[] SmallImage { get; set; }

        /// <summary>
        /// Mime type.
        /// </summary>
        public string MimeType { get; set; }

        /// <summary>
        /// Date of uploading.
        /// </summary>
        [Column(TypeName = "datetime2")]
        public DateTime Date { get; set; }

        /// <summary>
        /// Description.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Photo is avatar.
        /// </summary>
        public bool IsAvatar { get; set; }

        /// <summary>
        /// Photo belongs to the user.
        /// </summary>
        public int ProfileId { get; set; }

        /// <summary>
        /// User profile. It needs for db creating.
        /// </summary>
        public virtual Profile Profile { get; set; }
    }
}
