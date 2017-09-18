﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interface.Entities
{
    public class BllFriendship
    {
        public int Id { get; set; }

        public DateTime? RequestDate { get; set; }

        public int? UserFromId { get; set; }
        public int? UserToId { get; set; }
        public bool? IsConfirmed { get; set; }
    }
}
