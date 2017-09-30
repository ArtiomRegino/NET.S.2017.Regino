using System;
using System.Drawing.Imaging;
using System.Globalization;
using System.Web.Mvc;
using System.Web.Security;
using BLL.Interfaces.Interfaces;
using PL.Infrastructure;
using PL.Models.User;
using PL.Providers;

namespace PL.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        private readonly IUserService userService;
        private readonly IProfileService profileService;

        public AccountController(IUserService userService, IProfileService profileService)
        {
            this.userService = userService;
            this.profileService = profileService;
        }

        [HttpGet]
        [AllowAnonymous]
        public ActionResult Login(string returnUrl)
        {
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Home");
            }

            ViewBag.ReturnUrl = returnUrl;
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginViewModel loginModel, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                if (new CustomMembershipProvider().ValidateUser(loginModel.UserName, loginModel.Password))
                {
                    if (new CustomRoleProvider().IsUserInRole(loginModel.UserName, "BannedUser"))
                    {
                        return View("_BannedUserView");
                    }
                    FormsAuthentication.SetAuthCookie(loginModel.UserName, false);

                    if (Url.IsLocalUrl(returnUrl))
                        return Redirect(returnUrl);

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
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Home");
            }
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Registration(RegistrationViewModel registrationModel)
        {
            if (registrationModel.Captcha != (string)Session[CaptchaImage.CaptchaValueKey])
            {
                ModelState.AddModelError("Captcha", "Incorrect input.");
                return View(registrationModel);
            }

            var user = userService.GetUserByEmail(registrationModel.Email);
            if (user != null)
            {
                ModelState.AddModelError("", "User with such an email already exists.");
                return View(registrationModel);
            }

            if (ModelState.IsValid)
            {
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
        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }

        [AllowAnonymous]
        public ActionResult Captcha()
        {
            Session[CaptchaImage.CaptchaValueKey] =
                new Random(DateTime.Now.Millisecond).Next(1111, 9999).ToString(CultureInfo.InvariantCulture);
            var ci = new CaptchaImage(Session[CaptchaImage.CaptchaValueKey].ToString(), 211, 50, "Helvetica");

            Response.Clear();
            Response.ContentType = "image/jpeg";

            ci.Image.Save(Response.OutputStream, ImageFormat.Jpeg);

            ci.Dispose();
            return null;
        }
    }
}