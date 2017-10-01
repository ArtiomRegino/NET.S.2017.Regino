using System.Collections.Generic;
using BLL.Interfaces.Entities;

namespace BLL.Interfaces.Interfaces
{
    public interface IProfileService : IService<BllProfile>
    {
        BllProfile GetByUserEmail(string email);
        IEnumerable<BllProfile> FastSearch(string names);
        IEnumerable<BllProfile> FullSearch(BllProfile profile);
        void Update(IEnumerable<BllProfile> items);
    }
}
