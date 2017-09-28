using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PL.Models.Message
{
    public class DialogViewModel
    {
        public MessageViewModel Message { get; set; }
        public string NameOfCompanion { get; set; }
        public int? IdOfCompanion { get; set; }
        public int? PhotoIdOfCompanion { get; set; }
    }
}