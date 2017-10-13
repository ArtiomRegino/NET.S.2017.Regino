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
                BigImage = ormPhoto.BigImage,
                Date = ormPhoto.Date,
                MimeType = ormPhoto.MimeType,
                Description = ormPhoto.Description,
                SmallImage = ormPhoto.SmallImage,
                ProfileId = ormPhoto.ProfileId,
                Profile = ormPhoto.Profile.ToDalProfile(),
                IsAvatar = ormPhoto.IsAvatar
            };
        }

        public static Photo ToOrmPhoto(this DalPhoto dalPhoto)
        {
            if (dalPhoto == null) return null;

            var ormPhoto = new Photo()
            {
                Id = dalPhoto.Id,
                BigImage = dalPhoto.BigImage,
                Date = dalPhoto.Date,
                MimeType = dalPhoto.MimeType,
                SmallImage = dalPhoto.SmallImage,
                Description = dalPhoto.Description,
                ProfileId = dalPhoto.ProfileId,
                IsAvatar = dalPhoto.IsAvatar
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
