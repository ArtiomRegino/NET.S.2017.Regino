using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using BLL.Interfaces.Entities;
using BLL.Interfaces.Interfaces;
using PL.Mappers;
using PL.Models.Message;

namespace PL.Controllers
{
    /// <summary>
    /// Class for message sending logic.
    /// </summary>s
    [Authorize]
    public class MessageController : Controller
    {
        private readonly IUserService userService;
        private readonly IProfileService profileService;
        private readonly IMessageService messageService;

        /// <summary>
        /// Create Message Controller instance.
        /// </summary>
        public MessageController(IUserService userService, IProfileService profileService, IMessageService messageService)
        {
            this.userService = userService;
            this.profileService = profileService;
            this.messageService = messageService;
        }

        /// <summary>
        /// Get method for getting all the dialogs for current user.
        /// </summary>
        /// <returns>View with all the dialogs.</returns>
        [HttpGet]
        public ActionResult GetAllDialogs()
        {
            var curUser = userService.GetUserByUserName(User.Identity.Name);
            var lastMessages = messageService.GetLastMessagesOfTo(curUser.Id);

            var listOfDialogs = new List<DialogViewModel>();

            foreach (var item in lastMessages)
            {
                var companion = userService
                    .GetById(item.UserFromId == curUser.Id ? item.UserToId : item.UserFromId);
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

        /// <summary>
        /// Get metod for writing a message from someone's profile page.
        /// </summary>
        /// <param name="id">Id of profile to write to.</param>
        /// <returns>View with form for writing.</returns>
        [HttpGet]
        public ActionResult WriteSingleMessage(int? id)
        {
            var profile = profileService.GetById(id);

            return View("_WriteSingleMessageView", profile.ToSmallProfile());
        }

        /// <summary>
        /// Post netod for writing a message from someone's profile page.
        /// </summary>
        /// <param name="message">Message for user.</param>
        /// <returns>Main profile view.</returns>
        [HttpPost]
        public ActionResult WriteSingleMessage(RecivedMessageModel message)
        {
            WriteMessage(message);

            return RedirectToAction("Index", "Profile");
        }

        /// <summary>
        /// Method for showing all the messages(5) with current user.
        /// </summary>
        /// <param name="id">Id of user.</param>
        /// <returns>View with messages.</returns>
        [HttpGet]
        public ActionResult ShowDialog(int? id)
        {
            var companion = profileService.GetById(id);

            var profile = profileService.GetAll()
                .FirstOrDefault(p => p.UserName == User.Identity.Name);

            var messages = messageService.GetAll().Where(m =>
                    (m.UserFromId == profile.Id && m.UserToId == companion.Id)
                    || (m.UserFromId == companion.Id && m.UserToId == profile.Id))
                    .OrderByDescending(d => d.Date).Take(5).OrderBy(d => d.Date)
                    .Select(m => m.ToMvcMessage()).ToList();

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

        /// <summary>
        /// Post method for writing a message from dialog.
        /// </summary>
        /// <param name="message">Message.</param>
        /// <returns>View with last message.</returns>
        [HttpPost]
        public ActionResult WriteDialogMessage(RecivedMessageModel message)
        {
            var model = WriteMessage(message);

            if (Request.IsAjaxRequest())
                return PartialView("_SingleMessageView", model);

            return View("_SingleMessageView", model);
        }

        /// <summary>
        /// Get all user mesages.
        /// </summary>
        /// <param name="id">Id of user.</param>
        /// <returns>View with all the messages.</returns>
        [HttpGet]
        public ActionResult GetUserMessages(int? id)
        {
            var messages = messageService.GetAll()
                .Where(m => m.UserFromId == id).Select(m => m.ToMvcMessage());

            return View("_UserMessagesView", messages);
        }

        /// <summary>
        /// Get method for blocking some messages.
        /// </summary>
        /// <param name="id">Id of user.</param>
        /// <param name="curUser">Name of current user.</param>
        /// <returns>Form for selection.</returns>
        [HttpGet]
        [Authorize(Roles = "Admin")]
        public ActionResult BlockMessage(int? id, string curUser)
        {
            var message = messageService.GetById(id);
            message.Text = "Blocked";
            messageService.Update(message);

            return RedirectToAction("FilterUsers", "Profile");
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