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
    [Authorize]
    public class MessageController : Controller
    {
        private readonly IUserService userService;
        private readonly IProfileService profileService;
        private readonly IMessageService messageService;

        public MessageController(IUserService userService, IProfileService profileService, IMessageService messageService)
        {
            this.userService = userService;
            this.profileService = profileService;
            this.messageService = messageService;
        }

        [HttpGet]
        public ActionResult GetAllDialogs()
        {
            var curUser = userService.GetUserByUserName(User.Identity.Name);
            var lastMessages = messageService.GetLastMessagesOfTo(curUser.Id);

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
            WriteMessage(message);

            return RedirectToAction("Index", "Profile");
        }

        [HttpGet]
        public ActionResult ShowDialog(int? id)
        {
            var companion = profileService.GetById(id);

            var profile = profileService.GetAll().FirstOrDefault(p => p.UserName == User.Identity.Name);

            var messages = messageService.GetAll().Where(m =>
                    (m.UserFromId == profile.Id && m.UserToId == companion.Id) ||
                    (m.UserFromId == companion.Id && m.UserToId == profile.Id)).
                OrderByDescending(d => d.Date).Take(3).OrderBy(d => d.Date).
                Select(m => m.ToMvcMessage()).ToList();

            var model = new AllMessagesViewModel()
            {
                Messages = messages,
                NameOfCompanion = companion.FirstName,
                IdOfCompanion = id,
                PhotoIdOfCompanion = companion.PhotoId
            };

            if (Request.IsAjaxRequest())
                return PartialView("_MessagesViaDialogView", model);

            return View("_MessagesViaDialogView", model);
        }

        [HttpPost]
        public ActionResult WriteDialogMessage(RecivedMessageModel message)
        {
            var model = WriteMessage(message);

            if (Request.IsAjaxRequest())
                return PartialView("_SingleMessageView", model);

            return View("_SingleMessageView", model);
        }

        private MessageViewModel WriteMessage(RecivedMessageModel message)
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

            return bllMessage.ToMvcMessage();
        }
    }
}