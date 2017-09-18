using DAL.Interface.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interface.DTO
{
    public class DalProfile : IEntity
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public DateTime? BirthDate { get; set; }
        public int? PhotoId { get; set; }

        public virtual DalPhoto Photo { get; set; }

        public string City { get; set; }
        public bool? Gender { get; set; }

        public string ContactPhone { get; set; }

        public string AboutMe { get; set; }
    }
}
