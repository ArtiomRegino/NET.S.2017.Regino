using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ORM.Entities
{
    public class Image
    {
        public int Id { get; set; }
        public byte[] SmallImage { get; set; }
        public byte[] BigImage { get; set; }
        public string MimeType { get; set; }
        public string Description { get; set; }
    }
}
