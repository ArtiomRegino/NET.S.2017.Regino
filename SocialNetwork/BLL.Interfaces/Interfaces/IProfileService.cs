using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Interface.Entities;

namespace BLL.Interfaces.Interfaces
{
    public interface IProfileService : IService<BllProfile>
    {
        IEnumerable<BllProfile> Search(BllProfile profile);
        BllProfile GetByUserEmail(string email);
    }
}
