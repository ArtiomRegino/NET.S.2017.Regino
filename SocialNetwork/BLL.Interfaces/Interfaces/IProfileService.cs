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
        BllProfile GetByUserEmail(string email);
        IEnumerable<BllProfile> FastSearch(string names);
        IEnumerable<BllProfile> FullSearch(BllProfile profile);
    }
}
