using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Interface.DTO;
using ORM.Entities;

namespace DAL.Mappers
{
    public static class PhotoMapper
    {
        
        public static DalPhoto ToDalPhoto(this Photo ormPhoto)
        {
            if (ormPhoto == null) return null;

            return new DalPhoto()
            {
                Id = ormPhoto.Id,
                Data = ormPhoto.Data,
                Date = ormPhoto.Date,
                MimeType = ormPhoto.MimeType,
            };
        }

        public static Photo ToOrmPhoto(this DalPhoto dalPhoto)
        {
            if (dalPhoto == null) return null;

            var ormPhoto = new Photo()
            {
                Id = dalPhoto.Id,
                Data = dalPhoto.Data,
                Date = dalPhoto.Date,
                MimeType = dalPhoto.MimeType,

            };

            return ormPhoto;
        }
        public static IEnumerable<DalPhoto> ToDalPhoto(this IQueryable<Photo> ormPhotos)
        {
            var listOfPhotos = new List<DalPhoto>();
            foreach (var item in ormPhotos)
            {
                listOfPhotos.Add(item.ToDalPhoto());
            }

            return listOfPhotos;
        }
    }
}
