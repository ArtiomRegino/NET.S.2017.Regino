using System.Collections.Generic;
using System.Linq;
using BLL.Interfaces.Entities;
using BLL.Interfaces.Interfaces;
using BLL.Mappers;
using DAL.Interface.Interfaces;

namespace BLL.Servicies
{
    public class PhotoService: IPhotoService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IPhotoRepository photoRepository;

        public PhotoService(IUnitOfWork unitOfWork, IPhotoRepository photoRepository)
        {
            this.unitOfWork = unitOfWork;
            this.photoRepository = photoRepository;
        }

        public BllPhoto GetById(int? id)
        {
            BllPhoto photo = photoRepository.GetById(id).ToBllPhoto();
            unitOfWork.Commit();

            return photo;
        }

        public IEnumerable<BllPhoto> GetAll()
        {
            IEnumerable<BllPhoto> photos = photoRepository.GetAll().Map();
            unitOfWork.Commit();

            return photos;
        }

        public IEnumerable<BllPhoto> GetProfilePhotos(int profileId)
        {
            var photos = photoRepository.GetProfilePhotos(profileId);
            unitOfWork.Commit();

            return photos.Map();
        }

        public BllPhoto GetProfileAvatar(BllProfile profile)
        {
             return photoRepository.GetAll().Map()
                .FirstOrDefault(ph => ph.Profile.UserName == profile.UserName && ph.IsAvatar);
        }

        public void Create(BllPhoto item)
        {
            photoRepository.Create(item.ToDalPhoto());
            unitOfWork.Commit();
        }

        public void Delete(BllPhoto item)
        {
            photoRepository.Delete(item.ToDalPhoto());
            unitOfWork.Commit();
        }

        public void Update(BllPhoto item)
        {
            photoRepository.Update(item.ToDalPhoto());
            unitOfWork.Commit();
        }

        public void DeleteAll(int? id)
        {
            photoRepository.DeleteAll(id);
            unitOfWork.Commit();
        }
    }
}
