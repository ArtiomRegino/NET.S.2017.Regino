using System.Collections.Generic;
using BLL.Interfaces.Entities;

namespace BLL.Interfaces.Interfaces
{
    public interface IUserService : IService<BllUser>
    {
        BllUser GetUserByEmail(string email);
        BllUser GetUserByUserName(string username);
        void Update(IEnumerable<BllUser> users);
    }
}
