using DAL.Interface.DTO;

namespace DAL.Interface.Interfaces
{
    public interface IUserRepository : IRepository<DalUser>
    {
        DalUser GetUserByEmail(string email);
        DalUser GetUserByUserName(string username);
    }
}
