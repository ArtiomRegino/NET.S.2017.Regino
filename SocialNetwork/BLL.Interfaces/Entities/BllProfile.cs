using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interface.Entities
{
    public class BllProfile
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public DateTime? BirthDate { get; set; }
        public int? PhotoId { get; set; }

        public virtual BllPhoto Photo { get; set; }//зачем здесь виртуальность?

        public string City { get; set; }

        public bool? Gender { get; set; }

        public string ContactPhone { get; set; }

        public string AboutMe { get; set; }
    }
}
