using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PL.Models.Message
{
    public class MessageViewModel
    {
        public string Text { get; set; }
        public DateTime? Date { get; set; }
        public int? UserFromId { get; set; }
        public int? UserToId { get; set; }
        public string NameOfSender { get; set; }
    }
}