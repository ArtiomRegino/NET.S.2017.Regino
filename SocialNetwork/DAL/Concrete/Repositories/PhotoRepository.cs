using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using DAL.Interface.DTO;
using DAL.Interface.Interfaces;
using DAL.Mappers;
using ORM.Entities;

namespace DAL.Concrete.Repositories
{
    public class PhotoRepository: IPhotoRepository
    {
        private readonly DbContext context;

        public PhotoRepository(DbContext unitOfWork)
        {
            context = unitOfWork;
        }

        public void Create(DalPhoto e)
        {
            context.Set<Photo>().Add(e.ToOrmPhoto());
        }

        public void Delete(DalPhoto dalPhoto)
        {
            var userPhoto = context.Set<Photo>()
                .FirstOrDefault(p => p.Id == dalPhoto.Id);
            if (userPhoto == null)
                return;

            context.Set<Photo>().Attach(userPhoto);
            context.Set<Photo>().Remove(userPhoto);
            context.Entry(userPhoto).State = EntityState.Deleted;
        }

        public void DeleteAll(int? id)
        {
            var userPhotos = context.Set<Photo>().Where(p => p.ProfileId == id);

            foreach (var photo in userPhotos)
            {
                context.Set<Photo>().Attach(photo);
                context.Set<Photo>().Remove(photo);
                context.Entry(photo).State = EntityState.Deleted;
            }
        }

        public IEnumerable<DalPhoto> GetProfilePhotos(int profileId)
        {
            var photos = context.Set<Photo>().Where(u => u.ProfileId == profileId).ToList();

            return photos.Select(p => p.ToDalPhoto());
        }

        public IEnumerable<DalPhoto> GetAll()
        {
            var photos = context.Set<Photo>().Select(u => u).ToList();
            return photos.Select(p => p.ToDalPhoto());
        }

        public DalPhoto GetById(int? key)
        {
            var photo = context.Set<Photo>().Find(key);

            return photo?.ToDalPhoto();
        }

        public void Update(DalPhoto dalPhoto)
        {
            var photo = context.Set<Photo>().First(x => x.Id == dalPhoto.Id);
            context.Set<Photo>().Attach(photo);
            photo.BigImage = dalPhoto.BigImage;
            photo.ProfileId = dalPhoto.ProfileId;
            photo.SmallImage = dalPhoto.SmallImage;
            photo.Description = dalPhoto.Description;
            photo.MimeType = dalPhoto.MimeType;
            photo.Date = dalPhoto.Date;
            context.Entry(photo).State = EntityState.Modified;
        }
    }
}
