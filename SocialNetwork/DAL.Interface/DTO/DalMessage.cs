﻿using DAL.Interface.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interface.DTO
{
    public class DalMessage : IEntity
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public DateTime? Date { get; set; }

        public int? UserFromId { get; set; }

        public int? UserToId { get; set; }

        public virtual DalProfile UserTo { get; set; }

        public virtual DalProfile UserFrom { get; set; }
    }
}
