using DAL.Interface.Interfaces;

namespace DAL.Interface.DTO
{
    public class DalRole : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
