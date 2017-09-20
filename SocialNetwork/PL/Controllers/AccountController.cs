using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using BLL.Interfaces.Interfaces;
using PL.Models.User;
using PL.Providers;

namespace PL.Controllers
{
    public class AccountController : Controller
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
                if (new CustomMembershipProvider().ValidateUser(loginModel.UserName, loginModel.Password))
                {
                    FormsAuthentication.SetAuthCookie(loginModel.UserName, true);
                    return RedirectToAction("Index", "Profile");
                }
            }
            ModelState.AddModelError("", "Incorrect login or password.");

            return View(loginModel);
        }

        [HttpGet]
        [AllowAnonymous]
        public ActionResult Registration()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult Registration(RegistrationViewModel registrationModel)
        {
            if (ModelState.IsValid)
            {
                var user = userService.GetUserByEmail(registrationModel.Email);
                if (user != null)
                {
                    ModelState.AddModelError("", "User with such an email already exists.");
                    return View(registrationModel);
                }
                user = userService.GetUserByUserName(registrationModel.UserName);
                if (user != null)
                {
                    ModelState.AddModelError("", "User with such an username already exists.");
                    return View(registrationModel);
                }

                var membershipUser = ((CustomMembershipProvider) Membership.Provider)
                    .CreateUser(registrationModel.UserName, registrationModel.Password, registrationModel.Email);

                if (membershipUser != null)
                {
                    var profile = profileService.GetByUserEmail(registrationModel.Email);
                    profile.FirstName = registrationModel.FirstName;
                    profile.LastName = registrationModel.LastName;
                    profileService.Update(profile);
                }

                FormsAuthentication.SetAuthCookie(registrationModel.UserName, false);
                return RedirectToAction("Index", "Profile");
            }
            
            ModelState.AddModelError("", "Fill all the columns.");
            return View();
        }

        [HttpGet]
        [Authorize]
        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }
    }
}