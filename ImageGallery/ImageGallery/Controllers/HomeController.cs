using ORM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ImageGallery.Mappers;
using ImageGallery.Models;
using ORM.Entities;

namespace ImageGallery.Controllers
{
    [OutputCache(NoStore = true, Duration = 0)]
    public class HomeController : Controller
    {
        private readonly ImageGalleryContext context = new ImageGalleryContext();
        public int pageSize = 12;

        public ActionResult Index()
        {
            return RedirectToAction("GetImages");
        }

        [HttpGet]
        public ViewResult GetImages(int page = 1)
        {
            var model = new ImagesListViewModel
            {
                Images = context.Images.OrderBy(im => im.Id)
                    .Skip((page - 1) * pageSize)
                    .Take(pageSize).ToImageModel(),
                PagingInfo = new PagingInfoModel
                {
                    CurrentPage = page,
                    ItemsPerPage = pageSize,
                    TotalItems = context.Images.Count()
                }
            };

            return View("Index", model);
        }

        [HttpGet]
        public ActionResult UploadImage()
        {
            return View();
        }

        [HttpPost]
        public ActionResult UploadImage(HttpPostedFileBase postedImage, string description)
        {
            var newImage = new Image
            {
                BigImage = new byte[postedImage.ContentLength],
                MimeType = postedImage.ContentType,
                Description = description
            };

            postedImage.InputStream.Read(newImage.BigImage, 0, postedImage.ContentLength);

            newImage.SmallImage = ResizeImage(newImage.BigImage);
            context.Images.Add(newImage);
            context.SaveChanges();

            return RedirectToAction("Index");
        }

        private byte[] ResizeImage(byte[] arrayBytes)
        {
            var localMemStream = new System.IO.MemoryStream(arrayBytes);
            var fullsizeImage = System.Drawing.Image.FromStream(localMemStream);
            System.Drawing.Image newImage;
            if (fullsizeImage.Height > fullsizeImage.Width) 
                newImage = fullsizeImage.GetThumbnailImage(200, 300, null, IntPtr.Zero);
            else newImage = fullsizeImage.GetThumbnailImage(300, 200, null, IntPtr.Zero);

            var resultStream = new System.IO.MemoryStream();
            newImage.Save(resultStream, System.Drawing.Imaging.ImageFormat.Jpeg);  //Or whatever format you want.

            return resultStream.ToArray();  //Returns a new byte array.
        }

        public FileResult GetFullImage(int id)
        {
            var image = context.Images.FirstOrDefault(im => im.Id == id);

            //if (image.BigImage != null && image.MimeType != null)
                return File(image.BigImage, image.MimeType);

            //var path = Server.MapPath("~/Content/profile-default.png");

            //return File(path, "image/png");
        }

        public FileResult GetSmallImage(int id)
        {
            var image = context.Images.FirstOrDefault(im => im.Id == id);

            //if (image.BigImage != null && image.MimeType != null)
            return File(image.SmallImage, image.MimeType);

            //var path = Server.MapPath("~/Content/profile-default.png");

            //return File(path, "image/png");
        }
    }
}