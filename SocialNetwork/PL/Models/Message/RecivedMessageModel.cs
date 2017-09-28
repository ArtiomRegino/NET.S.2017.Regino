using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PL.Models.Message
{
    public class RecivedMessageModel
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public int? Recipient { get; set; }
    }
}