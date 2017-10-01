using System;

namespace BLL.Interfaces.Entities
{
    /// <summary>
    /// BLL layout message class.
    /// </summary>
    public class BllMessage
    {
        /// <summary>
        /// BllMessage id.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Text of BllMessage.
        /// </summary>
        public string Text { get; set; }

        /// <summary>
        /// BllMessage date of sending.
        /// </summary>
        public DateTime? Date { get; set; }

        /// <summary>
        /// BllMessage was sending by user with UserFromId.
        /// </summary>
        public int? UserFromId { get; set; }

        /// <summary>
        /// BllMessage was sending to user with UserToId.
        /// </summary>
        public int? UserToId { get; set; }

        /// <summary>
        /// Reference to user profile.
        /// </summary>
        public virtual BllProfile UserTo { get; set; }

        /// <summary>
        /// Reference to user profile.
        /// </summary>
        public virtual BllProfile UserFrom { get; set; }
    }
}
