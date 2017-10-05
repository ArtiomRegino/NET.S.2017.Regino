using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ORM.Entities;

namespace ORM
{
    public class ImageGalleryContext: DbContext
    {
        public ImageGalleryContext(): base("ImageGalleryContext")
        {
            Database.SetInitializer(new CreateDatabaseIfNotExists<ImageGalleryContext>());
        }

        public DbSet<Image> Images { get; set; }
    }
}
