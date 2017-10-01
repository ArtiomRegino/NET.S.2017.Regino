using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using BLL.Interfaces.Entities;
using BLL.Interfaces.Interfaces;
using PL.Mappers;

namespace PL.Controllers
{
    /// <summary>
    /// Class for friends and invite logic.
    /// </summary>
    [Authorize]
    public class FriendController : Controller
    {
        private readonly IUserService userService;
        private readonly IProfileService profileService;
        private readonly IFriendshipService friendshipService;

        /// <summary>
        /// Create Friend controller
        /// </summary>
        public FriendController(IUserService userService, IProfileService profileService, IFriendshipService friendshipService)
        {
            this.userService = userService;
            this.profileService = profileService;
            this.friendshipService = friendshipService;
        }

        /// <summary>
        /// Method for showing all the friend user have.
        /// </summary>
        /// <returns>List of friends.</returns>
        [HttpGet]
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

        /// <summary>
        /// Method for showing all requests user have.
        /// </summary>
        /// <returns>List of requests.</returns>
        [HttpGet]
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

        /// <summary>
        /// Method for confirming friendship.
        /// </summary>
        /// <param name="id">Id of new friend.</param>
        /// <returns>Main profile page.</returns>
        [HttpGet]
        public ActionResult ConfirmFriendship(int id)
        {
            var userId = userService.GetUserByUserName(User.Identity.Name).Id;
            friendshipService.Confirm(userId, id);

            return RedirectToAction("PresentationOfProfile", "Profile", new {Id = id });
        }

        /// <summary>
        /// Method for deleting someone from friends.
        /// </summary>
        /// <param name="id">Id of a friend.</param>
        /// <returns>Main profile page.</returns>
        [HttpGet]
        public ActionResult DeleteFriend(int id)
        {
            var userId = userService.GetUserByUserName(User.Identity.Name).Id;
            friendshipService.DeleteById(userId, id);

            return RedirectToAction("PresentationOfProfile", "Profile", new { Id = id });
        }

        /// <summary>
        /// Method for adding a new friend.
        /// </summary>
        /// <param name="id">Id of new friend.</param>
        /// <returns>Main profile page.</returns>
        [HttpGet]
        public ActionResult AddFriend(int id)
        {
            var userId = userService.GetUserByUserName(User.Identity.Name).Id;
            friendshipService.AddFriend(userId, id);

            return RedirectToAction("PresentationOfProfile", "Profile", new { Id = id });
        }
    }
}