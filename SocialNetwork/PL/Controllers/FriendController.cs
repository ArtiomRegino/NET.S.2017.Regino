using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BLL.Interface.Entities;
using BLL.Interfaces.Interfaces;
using PL.Mappers;

namespace PL.Controllers
{
    public class FriendController : Controller
    {
        private readonly IUserService userService;
        private readonly IProfileService profileService;
        private readonly IPhotoService photoService;
        private readonly IMessageService messageService;
        private readonly IFriendshipService friendshipService;

        public FriendController(IUserService userService, IProfileService profileService, IPhotoService photoService, IMessageService messageService, IFriendshipService friendshipService)
        {
            this.userService = userService;
            this.profileService = profileService;
            this.photoService = photoService;
            this.messageService = messageService;
            this.friendshipService = friendshipService;
        }

        public ActionResult ShowFriendList()
        {
            var profileList = new List<BllProfile>();

            if (User.Identity.IsAuthenticated)
            {
                var userId = userService.GetUserByUserName(User.Identity.Name).Id;
                var bllFriendships = friendshipService.GetAll()
                    .Where(fr => (fr.UserFromId == userId && fr.IsConfirmed == true)
                                 || (fr.UserToId == userId && fr.IsConfirmed == true));

                foreach (var item in bllFriendships)
                {
                    profileList.Add(item.UserFromId != userId
                        ? profileService.GetById((int) item.UserFromId)
                        : profileService.GetById((int) item.UserToId));
                }
            }
            if (Request.IsAjaxRequest())
                return PartialView("FriendListView", profileList.ToPresentations().ToList());

            return View("FriendListView", profileList.ToPresentations().ToList());
        }

        public ActionResult RequestFriendList()
        {
            var profileList = new List<BllProfile>();

            
            if (User.Identity.IsAuthenticated)
            {
                var userId = userService.GetUserByUserName(User.Identity.Name).Id;
                var bllFriendships = friendshipService.GetAll()
                    .Where(fr => fr.UserToId == userId && fr.IsConfirmed == false);

                foreach (var item in bllFriendships)
                {
                    profileList.Add(profileService.GetById((int)item.UserFromId));
                }      
            }
            if (Request.IsAjaxRequest())
            {
                return PartialView("RequestsListView", profileList.ToPresentations().ToList());
            }

            return View("RequestsListView", profileList.ToPresentations().ToList());
        }

        [HttpGet]
        public ActionResult ConfirmFriendship(int id)
        {
            var userId = userService.GetUserByUserName(User.Identity.Name).Id;
            friendshipService.Confirm(userId, id);

            return RedirectToAction("PresentationOfProfile", "Profile", new {Id = id });
        }

        [HttpGet]
        public ActionResult DeleteFriend(int id)
        {
            var userId = userService.GetUserByUserName(User.Identity.Name).Id;
            friendshipService.DeleteById(userId, id);

            return RedirectToAction("PresentationOfProfile", "Profile", new { Id = id });
        }

        [HttpGet]
        public ActionResult AddFriend(int id)
        {
            var userId = userService.GetUserByUserName(User.Identity.Name).Id;
            friendshipService.AddFriend(userId, id);

            return RedirectToAction("PresentationOfProfile", "Profile", new { Id = id });
        }
    }
}