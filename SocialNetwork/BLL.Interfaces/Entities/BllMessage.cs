using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interface.Entities
{
    public class BllMessage
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public DateTime? Date { get; set; }

        public int? UserFromId { get; set; }

        public int? UserToId { get; set; }

        public virtual BllProfile UserTo { get; set; }

        public virtual BllProfile UserFrom { get; set; }
    }
}
