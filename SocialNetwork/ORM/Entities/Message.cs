using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace ORM.Entities
{
    /// <summary>
    /// ORM layout message class.
    /// </summary>
    public class Message
    {
        public Message()
        {
            Date = DateTime.Now;
        }

        /// <summary>
        /// Message id.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Message was sending by user with UserFromId.
        /// </summary>
        public int? UserFromId { get; set; }

        /// <summary>
        /// Message was sending to user with UserToId.
        /// </summary>
        public int? UserToId { get; set; }

        /// <summary>
        /// Text of message.
        /// </summary>
        public string Text { get; set; }

        /// <summary>
        /// Date and time of sending.
        /// </summary>
        [Column(TypeName = "datetime2")]
        public DateTime? Date { get; set; }

        /// <summary>
        /// Reference to user profile.
        /// </summary>
        [ForeignKey("UserToId")]
        public virtual Profile UserTo { get; set; }

        /// <summary>
        /// Reference to user profile.
        /// </summary>
        [ForeignKey("UserFromId")]
        public virtual Profile UserFrom { get; set; }


    }
}
