using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            this.context = unitOfWork;
        }
        public void Create(DalPhoto e)
        {
            context.Set<Photo>().Add(e.ToOrmPhoto());
        }

        public void Delete(DalPhoto e)
        {
            var userPhoto = context.Set<Photo>().FirstOrDefault(p => p.Id == e.Id);
            context.Set<Photo>().Attach(userPhoto);
            context.Set<Photo>().Remove(userPhoto);
            context.Entry(userPhoto).State = System.Data.Entity.EntityState.Deleted;
        }

        public IEnumerable<DalPhoto> GetAll()
        {
            var photos = context.Set<Photo>().Select(u => u).ToList();
            return photos.Select(p => p.ToDalPhoto());
        }

        public DalPhoto GetById(int key)
        {
            var photo = context.Set<Photo>().Find(key);
            if (photo == null)
                return null;
            return photo.ToDalPhoto();
        }

        public void Update(DalPhoto e)
        {
            var photo = context.Set<Photo>().First(x => x.Id == e.Id);
            context.Set<Photo>().Attach(photo);
            photo.Data = e.Data;
            photo.MimeType = e.MimeType;
            photo.Date = e.Date;
            context.Entry(photo).State = EntityState.Modified;
        }
    }
}
