using DAL.Interface.DTO;

namespace DAL.Interface.Interfaces
{
    public interface IProfileRepository : IRepository<DalProfile>
    {
        DalProfile GetByUserEmail(string email);
        void AddPhoto(DalPhoto item);
    }
}
