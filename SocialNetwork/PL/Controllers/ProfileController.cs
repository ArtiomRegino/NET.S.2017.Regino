using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using System.Web.Security;
using BLL.Interfaces.Interfaces;
using PL.Models.Profile;
using PL.Providers;

namespace PL.Controllers
{
    public class ProfileController : Controller
    {
        private readonly IUserService userService;
        private readonly IProfileService profileService;
        private readonly IPhotoService photoService;
        private readonly IMessageService messageService;
        private readonly IFriendshipService friendshipService;

        public ProfileController(IUserService userService, IProfileService profileService, IPhotoService photoService, IMessageService messageService, IFriendshipService friendshipService)
        {
            this.userService = userService;
            this.profileService = profileService;
            this.photoService = photoService;
            this.messageService = messageService;
            this.friendshipService = friendshipService;
        }

        [Authorize]
        [HttpGet]
        public ActionResult Index()
        {
            if (Request.IsAjaxRequest())
            {
                return PartialView("_ProfileWall");
            }
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
            var user = userService.GetUserByUserName(User.Identity.Name);
            var profile = user.Profile;

            ViewBag.Profile = profile;

            return View("_EditProfile");
        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(EditProfileViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = userService.GetUserByUserName(User.Identity.Name);
                var profile = user.Profile;
                profile.AboutMe = model.AboutMe;
                profile.City = model.City;
                profile.ContactPhone = model.ContactPhone;
                profile.FirstName = model.FirstName;
                profile.LastName = model.LastName;
                profile.BirthDate = model.BirthDate;
                profile.Gender = model.Gender;

                profileService.Update(user.Profile);
                return RedirectToAction("Index", "Home");
            }
            ModelState.AddModelError("", "Enter all lines.");

            return View("_EditProfile", model);
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
            if (ModelState.IsValid)
            {
                if ((new CustomMembershipProvider()).ValidateUser(User.Identity.Name, model.OldPassword))
                {
                    var user = userService.GetUserByUserName(User.Identity.Name);
                    if (model.Email != null)
                    {
                        user.Email = model.Email;
                    }
                    user.Password = Crypto.HashPassword(model.NewPassword);
                    userService.Update(user);

                    return RedirectToAction("Index", "Home");
                }
                ModelState.AddModelError("", "Incorrect old password.");

                return View("_ProfileSettings", model);
            }

            ModelState.AddModelError("", "Input all info.");
            return View("_ProfileSettings", model);
        }

        [Authorize]
        [HttpGet]
        public ActionResult HelpAbout()
        {
            return View("_HelpAboutProfile");
        }

        [Authorize]
        [HttpGet]
        public ActionResult Delete()
        {
            var user = userService.GetUserByUserName(User.Identity.Name);
            FormsAuthentication.SignOut();

            friendshipService.DeleteAllUserRelationById(user.Id);
            messageService.DeleteAllUserMessagesById(user.Id);
            photoService.Delete(user.Profile.Photo);
            profileService.Delete(user.Profile);
            userService.Delete(user);

            return RedirectToAction("Index", "Home");
        }
    }
}