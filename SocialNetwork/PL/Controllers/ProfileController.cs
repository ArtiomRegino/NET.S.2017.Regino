using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using System.Web.Security;
using BLL.Interface.Entities;
using BLL.Interfaces.Interfaces;
using PL.Mappers;
using PL.Models.Profile;
using PL.Models.Search;
using PL.Providers;

namespace PL.Controllers
{
    [Authorize]
    public class ProfileController : Controller
    {
        private readonly IUserService userService;
        private readonly IProfileService profileService;
        private readonly IPhotoService photoService;
        private readonly IMessageService messageService;
        private readonly IFriendshipService friendshipService;
        private readonly IRoleService roleService;

        public ProfileController(IUserService userService, IRoleService roleService, IProfileService profileService, IPhotoService photoService, IMessageService messageService, IFriendshipService friendshipService)
        {
            this.userService = userService;
            this.profileService = profileService;
            this.photoService = photoService;
            this.messageService = messageService;
            this.friendshipService = friendshipService;
            this.roleService = roleService;
        }

        [HttpGet]
        public ActionResult Index()
        {
            var profile = profileService.GetAll().FirstOrDefault(p => p.UserName == User.Identity.Name);
            var presentProfile = profile.ToPresentation();

            if (Request.IsAjaxRequest())
            {
                return PartialView("_ProfileWall", presentProfile);
            }
            return View("_ProfileWall", presentProfile);
        }

        [HttpPost]
        public ActionResult SearchByNames(string names)
        {
            List<SearchResultViewModel> profiles;

            if (Request.IsAjaxRequest())
            {
                if (string.IsNullOrEmpty(names))
                    return PartialView("_SearchResultView", null);

                profiles = profileService.FastSearch(names).ToSearchResultModel().ToList();

                return PartialView("_SearchResultView", profiles);
            }

            if (string.IsNullOrEmpty(names))
                return View("_SearchResultView", null);

            profiles = profileService.FastSearch(names).ToSearchResultModel().ToList();

            return View("_SearchResultView", profiles);
        }

        [HttpGet]
        public ActionResult FullSearch()
        {
            return View("_FullSearchView");
        }

        [HttpPost]
        public ActionResult FullSearch(FullSearchViewModel model)
        {
            var profile = model.ToBllProfile();
            var profiles = profileService.FullSearch(profile).ToSearchResultModel().ToList();

            return View("_SearchResultView", profiles.ToList());
        }

        [HttpGet]
        public ActionResult Edit()
        {
            var user = userService.GetUserByUserName(User.Identity.Name);
            var profile = user.Profile;

            ViewBag.Profile = profile;

            return View("_EditProfile");
        }

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

        [HttpGet]
        public ActionResult Settings()
        {
            return View("_ProfileSettings");
        }

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

        [HttpGet]
        public ActionResult HelpAbout()
        {
            return View("_HelpAboutProfile");
        }

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

        [HttpGet]
        public ActionResult PresentationOfProfile(int id)
        {
            var profile = profileService.GetAll().FirstOrDefault(p => p.Id == id);
            var currentUserId = userService.GetUserByUserName(User.Identity.Name).Id;
            ViewBag.IsFriend = friendshipService.IsFriend(currentUserId, id);

            return View("_ProfileWall", profile.ToPresentation());
        }

        [HttpGet]
        public ActionResult UploadImage()
        {
            return View("EditAvatarView");
        }

        [HttpPost]
        public ActionResult UploadImage(HttpPostedFileBase image)
        {
            if (image == null) return RedirectToAction("Index");

            var user = userService.GetUserByUserName(User.Identity.Name);
            var photo = user.Profile.Photo;
            photo.MimeType = image.ContentType;
            photo.Data = new byte[image.ContentLength];
            image.InputStream.Read(photo.Data, 0, image.ContentLength);
            photoService.Update(photo);

            return RedirectToAction("Index"); 
        }

        public FileResult GetImage(int id)
        {
            var image = photoService.GetById(id);

            if (image.Data != null && image.MimeType != null)
                return File(image.Data, image.MimeType);

            var path = Server.MapPath("~/Content/profile-default.png");

            return File(path, "image/png");
        }

        [HttpGet]
        public ActionResult ManageUsers()
        {
            if (!(new CustomRoleProvider().IsUserInRole(User.Identity.Name, "Admin")))
                return RedirectToAction("Index", "Home");

            var profiles = profileService.GetAll().ToManagmentModel();

            if (Request.IsAjaxRequest())
                return PartialView("_ManagmentView", profiles.ToList());

            return View("_ManagmentView", profiles.ToList());
        }

        [HttpPost]
        public ActionResult ManageUsers(FormCollection form, string command)
        {
            var idsArraySplit = form["Check"].Split(',');
            var allUsers = userService.GetAll();
            var managedUsers = idsArraySplit.Select(item => allUsers.
                FirstOrDefault(p => p.Id == int.Parse(item))).ToList();

            if (command.Equals("Active"))
            {
                managedUsers = ChangeRole(managedUsers, "ActiveUser");
                userService.Update(managedUsers);
            }
            if (command.Equals("Banned"))
            {
                managedUsers = ChangeRole(managedUsers, "BannedUser");
                userService.Update(managedUsers);
            }
            if (command.Equals("Moderator"))
            {
                managedUsers = ChangeRole(managedUsers, "Moderator");
                userService.Update(managedUsers);
            }
            if (command.Equals("Delete"))
            {
                foreach (var item in managedUsers)
                {
                    userService.Delete(item);
                }
            }

                return RedirectToAction("ManageUsers");
        }

        [HttpGet]
        public ActionResult FilterUsers()
        {
            if (!(new CustomRoleProvider().IsUserInRole(User.Identity.Name, "Admin")))
                return RedirectToAction("Index", "Home");

            var profiles = profileService.GetAll().ToManagmentModel();

            if (Request.IsAjaxRequest())
                return PartialView("_MessageFilterView", profiles.ToList());

            return View("_MessageFilterView", profiles.ToList());
        }

        private List<BllUser> ChangeRole(List<BllUser> users, string role)
        {
            var currentRole = roleService.GetByName(role);
            foreach (var item in users)
            {
                item.RoleId = currentRole.Id;
            }

            return users;
        }
    }
}