using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Interface.Entities;
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
                Data = dalPhoto.Data,
                Date = dalPhoto.Date,
                MimeType = dalPhoto.MimeType,

            };

            return bllPhoto;
        }
        public static DalPhoto ToDalPhoto(this BllPhoto bllPhoto)
        {
            if (bllPhoto == null) return null;

            return new DalPhoto()
            {
                Id = bllPhoto.Id,
                Data = bllPhoto.Data,
                Date = bllPhoto.Date,
                MimeType = bllPhoto.MimeType,
            };
        }

        public static IEnumerable<BllPhoto> Map(this IEnumerable<DalPhoto> dalPhotos)
        {
            var listOfPhotos = new List<BllPhoto>();
            foreach (var item in dalPhotos)
            {
                listOfPhotos.Add(item.ToBllPhoto());
            }

            return listOfPhotos;
        }
    }
}
