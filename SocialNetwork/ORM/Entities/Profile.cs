using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ORM.Entities
{
    /// <summary>
    /// ORM layout profile class.
    /// </summary>
    public class Profile
    {
        /// <summary>
        /// Profile id.
        /// </summary>
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// User name.
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// User first name.
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// User last name.
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// User date of birth.
        /// </summary>
        [Column(TypeName = "datetime2")]
        public DateTime? BirthDate { get; set; }

        /// <summary>
        /// It needs for db creating.
        /// </summary>
        public virtual Photo Photo { get; set; }

        /// <summary>
        /// User photo id.
        /// </summary>
        [ForeignKey("Photo")]
        public int? PhotoId { get; set; }

        /// <summary>
        /// Name of city where user live.
        /// </summary>
        public string City { get; set; }

        /// <summary>
        /// User gender.
        /// </summary>
        public bool? Gender { get; set; }

        /// <summary>
        /// User contact phone.
        /// </summary>
        public string ContactPhone { get; set; }

        /// <summary>
        /// User additional information.
        /// </summary>
        public string AboutMe { get; set; }

    }
}
