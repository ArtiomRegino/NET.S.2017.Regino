using System.Collections.Generic;
using BLL.Interfaces.Entities;

namespace BLL.Interfaces.Interfaces
{
    public interface IPhotoService : IService<BllPhoto>
    {
        void DeleteAll(int? id);
        BllPhoto GetProfileAvatar(BllProfile profile);
        IEnumerable<BllPhoto> GetProfilePhotos(int profileId);
    }
}
