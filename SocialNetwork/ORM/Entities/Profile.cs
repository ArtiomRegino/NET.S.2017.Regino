using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ORM.Entities
{
    public class Profile
    {
        [Key]
        public int Id { get; set; }
        public string UserName { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? BirthDate { get; set; }

        public virtual Photo Photo { get; set; }

        [ForeignKey("Photo")]
        public int? PhotoId { get; set; }
        public string City { get; set; }
        public bool? Gender { get; set; }

        public string ContactPhone { get; set; }

        public string AboutMe { get; set; }

    }
}
