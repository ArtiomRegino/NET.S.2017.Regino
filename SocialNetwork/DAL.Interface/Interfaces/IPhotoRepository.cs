using System.Collections.Generic;
using DAL.Interface.DTO;

namespace DAL.Interface.Interfaces
{
    public interface IPhotoRepository: IRepository<DalPhoto>
    {
        void DeleteAll(int? id);
        IEnumerable<DalPhoto> GetProfilePhotos(int profileId);
    }
}
