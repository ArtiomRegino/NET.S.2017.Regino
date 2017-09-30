using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace ORM.Entities
{
    /// <summary>
    /// ORM layout friendship class.
    /// </summary>
    public class Friendship
    {
        /// <summary>
        /// Friendship id.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Date of friendship request.
        /// </summary>
        [Column(TypeName = "datetime2")]
        public DateTime? RequestDate { get; set; }

        /// <summary>
        /// Request was sending by user with UserFromId.
        /// </summary>
        [ForeignKey("ToUser")]
        public int? UserFromId { get; set; }

        /// <summary>
        /// Request was sending to user with UserToId.
        /// </summary>
        [ForeignKey("FromUser")]
        public int? UserToId { get; set; }

        /// <summary>
        /// Request was confirmed by user with UserToId.
        /// </summary>
        public bool? IsConfirmed { get; set; }

        /// <summary>
        /// Reference to user.
        /// </summary>
        public virtual User FromUser { get; set; }

        /// <summary>
        /// Reference to user.
        /// </summary>
        public virtual User ToUser { get; set; }

    }
}
