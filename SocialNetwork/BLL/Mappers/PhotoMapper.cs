using System.Collections.Generic;
using System.Linq;
using BLL.Interfaces.Entities;
using DAL.Interface.DTO;

namespace BLL.Mappers
{
    public static class PhotoMapper
    {
        public static BllPhoto ToBllPhoto(this DalPhoto dalPhoto)
        {
            if (dalPhoto == null) return null;

            var bllPhoto = new BllPhoto()
            {
                Id = dalPhoto.Id,
                BigImage = dalPhoto.BigImage,
                SmallImage = dalPhoto.SmallImage,
                Profile = dalPhoto.Profile.ToBllProfile(),
                Description = dalPhoto.Description,
                ProfileId = dalPhoto.ProfileId,
                Date = dalPhoto.Date,
                MimeType = dalPhoto.MimeType,
                IsAvatar = dalPhoto.IsAvatar

            };

            return bllPhoto;
        }
        public static DalPhoto ToDalPhoto(this BllPhoto bllPhoto)
        {
            if (bllPhoto == null) return null;

            return new DalPhoto()
            {
                Id = bllPhoto.Id,
                BigImage = bllPhoto.BigImage,
                SmallImage = bllPhoto.SmallImage,
                Description = bllPhoto.Description,
                ProfileId = bllPhoto.ProfileId,
                Date = bllPhoto.Date,
                MimeType = bllPhoto.MimeType,
                IsAvatar = bllPhoto.IsAvatar
            };
        }

        public static IEnumerable<BllPhoto> Map(this IEnumerable<DalPhoto> dalPhotos)
        {
            return dalPhotos.Select(item => item.ToBllPhoto()).ToList();
        }
    }
}
