using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ORM.Entities
{
    public class Message
    {
        public Message()
        {
            Date = DateTime.Now;
        }
        public int Id { get; set; }
        public int? UserFromId { get; set; }
        public int? UserToId { get; set; }
        public string Text { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? Date { get; set; }
        [ForeignKey("UserToId")]
        public virtual Profile UserTo { get; set; }
        [ForeignKey("UserFromId")]
        public virtual Profile UserFrom { get; set; }


    }
}
