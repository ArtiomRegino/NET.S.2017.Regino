using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BLL.Interfaces.Interfaces;
using PL.Models.User;

namespace PL.Controllers
{
    public class AccountController : Controller//подключить в конфиг провайдеров
    {
        private IUserService userService;
        private IProfileService profileService;

        public AccountController(IUserService userService, IProfileService profileService)
        {
            this.userService = userService;
            this.profileService = profileService;
        }

        [HttpGet]
        [AllowAnonymous]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult Login(LoginViewModel loginModel)
        {
            if (ModelState.IsValid)
            {
                
            }
            return View();
        }

        [HttpGet]
        [AllowAnonymous]
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult Register(RegistrationViewModel registrationModel)
        {
            if (ModelState.IsValid)
            {

            }
            return View();
        }
    }
}