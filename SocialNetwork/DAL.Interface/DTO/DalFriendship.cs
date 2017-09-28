﻿using System;
using DAL.Interface.Interfaces;

namespace DAL.Interface.DTO
{
    public class DalFriendship : IEntity
    {
        public int Id { get; set; }
        public DateTime? RequestDate { get; set; }
        public int? UserFromId { get; set; }
        public int? UserToId { get; set; }
        public bool? IsConfirmed { get; set; }
    }
}
