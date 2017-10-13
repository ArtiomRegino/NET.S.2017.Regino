using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PL.Models.Photo
{
    public class PagingInfoModel
    {
        public int TotalItems { get; set; }
        public int ItemsPerPage { get; set; }
        public int CurrentPage { get; set; }
        public int TotalPages => (int)Math.Ceiling((decimal)TotalItems / ItemsPerPage);
    }
}