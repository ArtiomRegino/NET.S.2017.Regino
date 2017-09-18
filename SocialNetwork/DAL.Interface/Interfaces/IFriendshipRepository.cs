using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Interface.DTO;
using ORM.Entities;

namespace DAL.Interface.Interfaces
{
    public interface IFriendshipRepository: IRepository<DalFriendship>
    {
        void DeleteAllUserRelationById(int id);
    }
}
