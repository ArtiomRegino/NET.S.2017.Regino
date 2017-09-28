using DAL.Interface.Interfaces;
using System;

namespace DAL.Interface.DTO
{
    public class DalPhoto : IEntity
    {
        public int Id { get; set; }
        public byte[] Data { get; set; }
        public string MimeType { get; set; }
        public DateTime Date { get; set; }
    }
}
