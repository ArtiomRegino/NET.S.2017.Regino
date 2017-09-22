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
        public ActionResult Edit()
        {
            return View("_EditProfile");
        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(EditProfileViewModel model)
        {
            return View();
        }

        [Authorize]
        [HttpGet]
        public ActionResult Settings()
        {
            return View("_ProfileSettings");
        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Settings(ProfileSettingsViewModel model)
        {
            return View();
        }
    }
}