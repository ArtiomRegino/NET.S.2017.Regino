using System.Collections.Generic;

namespace PL.Models.Photo
{
    public class ImagesListViewModel
    {
        public int ProfileId { get; set; }
        public int AuthorizedId { get; set; }
        public List<ImageModel> Images { get; set; }
        public PagingInfoModel PagingInfo { get; set; }
    }
}