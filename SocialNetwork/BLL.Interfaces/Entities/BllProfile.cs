using System;

namespace BLL.Interfaces.Entities
{
    /// <summary>
    /// BLL layout profile class.
    /// </summary>
    public class BllProfile
    {
        /// <summary>
        /// BllProfile id.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// BllProfile first name.
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// BllProfile last name.
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// BllProfile username.
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// BllProfile date of birth.
        /// </summary>
        public DateTime? BirthDate { get; set; }

        /// <summary>
        /// BllProfile photo id.
        /// </summary>
        public int? PhotoId { get; set; }

        /// <summary>
        /// BllProfile reference to photo.
        /// </summary>
        public BllPhoto Photo { get; set; }

        /// <summary>
        /// BllProfile name of city.
        /// </summary>
        public string City { get; set; }

        /// <summary>
        /// BllProfile gender.
        /// </summary>
        public bool? Gender { get; set; }

        /// <summary>
        /// BllProfile contact phone.
        /// </summary>
        public string ContactPhone { get; set; }

        /// <summary>
        /// BllProfile additional information.
        /// </summary>
        public string AboutMe { get; set; }
    }
}
