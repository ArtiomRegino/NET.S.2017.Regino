using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ImageGallery.Models;
using ORM.Entities;

namespace ImageGallery.Mappers
{
    public static class MvcMapper
    {
        public static ImageModel ToImageModel(this Image img)
        {
            var imgModel = new ImageModel
            {
                Id = img.Id,
                Description = img.Description,
                Image = $"/Home/GetFullImage/{img.Id}",
                ImageSmall = $"/Home/GetSmallImage/{img.Id}"
            };

            return imgModel;
        }

        public static List<ImageModel> ToImageModel(this IQueryable<Image> images)
        {
            var imageModels = new List<ImageModel>();

            foreach (var item in images)
            {
                imageModels.Add(item.ToImageModel());
            }

            return imageModels;
        }
    }
}