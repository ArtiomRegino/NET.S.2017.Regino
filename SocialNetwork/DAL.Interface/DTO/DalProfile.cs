using DAL.Interface.Interfaces;
using System;

namespace DAL.Interface.DTO
{
    /// <summary>
    /// DAL layout profile class.
    /// </summary>
    public class DalProfile : IEntity
    {
        /// <summary>
        /// DalProfile id.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// DalProfile first name.
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// DalProfile last name.
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// DalProfile username.
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// DalProfile date of birth.
        /// </summary>
        public DateTime? BirthDate { get; set; }

        /// <summary>
        /// DalProfile photo id.
        /// </summary>
        public int? PhotoId { get; set; }

        /// <summary>
        /// DalProfile reference to photo.
        /// </summary>
        public DalPhoto Photo { get; set; }

        /// <summary>
        /// DalProfile name of city.
        /// </summary>
        public string City { get; set; }

        /// <summary>
        /// DalProfile gender.
        /// </summary>
        public bool? Gender { get; set; }

        /// <summary>
        /// DalProfile contact phone.
        /// </summary>
        public string ContactPhone { get; set; }

        /// <summary>
        /// DalProfile additional information.
        /// </summary>
        public string AboutMe { get; set; }
    }
}
