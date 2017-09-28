using DAL.Interface.DTO;

namespace DAL.Interface.Interfaces
{
    public interface IFriendshipRepository: IRepository<DalFriendship>
    {
        void DeleteAllUserRelationById(int id);
    }
}
