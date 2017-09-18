using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ORM.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string UserName { get; set; }

        public string Password { get; set; }

        public string Email { get; set; }

        public int? ProfileId { get; set; }

        public virtual Profile Profile { get; set; }

        public int RoleId { get; set; }
        public virtual Role Role { get; set; }
    }
}
