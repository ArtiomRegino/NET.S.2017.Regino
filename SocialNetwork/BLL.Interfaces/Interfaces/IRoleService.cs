using BLL.Interfaces.Entities;

namespace BLL.Interfaces.Interfaces
{
    public interface IRoleService : IService<BllRole>
    {
        BllRole GetByName(string name);
    }
}
