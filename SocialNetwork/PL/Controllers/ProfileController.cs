using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PL.Models.Profile;

namespace PL.Controllers
{
    public class ProfileController : Controller
    {
        
        [Authorize]
        [HttpGet]
        public ActionResult Index()
        {
            return View("_ProfileWall");
        }

        [Authorize]
        [HttpGet]
        public ActionResult Search()
        {
            return View("_ProfileWall");
        }

        [Authorize]
        [HttpGet]
        public ActionResult EditProfile()
        {
            return View();
        }

        [Authorize]
        [HttpPost]
        public ActionResult EditProfile(EditProfileViewModel model)
        {
            return View();
        }
    }
}