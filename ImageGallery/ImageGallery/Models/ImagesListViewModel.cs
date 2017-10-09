using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ORM.Entities;

namespace ImageGallery.Models
{
    public class ImagesListViewModel
    {
            public List<ImageModel> Images { get; set; }
            public PagingInfoModel PagingInfo { get; set; }
    }
}