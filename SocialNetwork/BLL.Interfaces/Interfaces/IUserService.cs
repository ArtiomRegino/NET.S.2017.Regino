using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Interface.Entities;

namespace BLL.Interfaces.Interfaces
{
    public interface IUserService : IService<BllUser>
    {
        BllUser GetUserByEmail(string email);
        BllUser GetUserByUserName(string username);
    }
}
