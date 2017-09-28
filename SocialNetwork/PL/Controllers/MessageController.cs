using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BLL.Interface.Entities;
using BLL.Interfaces.Interfaces;
using PL.Mappers;
using PL.Models.Message;

namespace PL.Controllers
{
    public class MessageController : Controller
    {
        private readonly IUserService userService;
        private readonly IProfileService profileService;
        private readonly IPhotoService photoService;
        private readonly IMessageService messageService;
        private readonly IFriendshipService friendshipService;

        public MessageController(IUserService userService, IProfileService profileService, IPhotoService photoService, IMessageService messageService, IFriendshipService friendshipService)
        {
            this.userService = userService;
            this.profileService = profileService;
            this.photoService = photoService;
            this.messageService = messageService;
            this.friendshipService = friendshipService;
        }

        [HttpGet]
        public ActionResult GetAllDialogs()
        {
            var curUser = userService.GetUserByUserName(User.Identity.Name);
            var lastMessages = messageService.GetLastMessagesOfTo(curUser.Id);

            //profileId photoId lastMessage dateOfMessage profileName
            var listOfDialogs = new List<DialogViewModel>();

            foreach (var item in lastMessages)
            {
                var companion = userService.GetById(item.UserFromId == curUser.Id ? item.UserToId : item.UserFromId);
                var dialog = new DialogViewModel()
                {
                    Message = item.ToMvcMessage(),
                    IdOfCompanion = item.UserFromId == curUser.Id ? item.UserToId : item.UserFromId,
                    NameOfCompanion = $"{companion.Profile.FirstName} {companion.Profile.LastName}",
                    PhotoIdOfCompanion = companion.Profile.PhotoId
                };

                listOfDialogs.Add(dialog);
            }

            if (Request.IsAjaxRequest())
            {
                return PartialView("DialogsView", listOfDialogs);
            }

            return View("DialogsView", listOfDialogs);
        }

        [HttpGet]
        public ActionResult WriteSingleMessage(int? id)
        {
            var profile = profileService.GetById(id);

            return View("_WriteSingleMessageView", profile.ToSmallProfile());
        }

        [HttpPost]
        public ActionResult WriteSingleMessage(RecivedMessageModel message)
        {
            var userFrom = userService.GetUserByUserName(User.Identity.Name).Profile;

            var bllMessage = new BllMessage()
                                    {
                                        Date = DateTime.Now,
                                        Text = message.Text,
                                        UserFrom = userFrom,
                                        UserFromId = userFrom.Id,
                                        UserTo = profileService.GetById(message.Id),
                                        UserToId = message.Id
                                    };

            messageService.Create(bllMessage);

            return RedirectToAction("Index", "Profile");
        }
    }
}