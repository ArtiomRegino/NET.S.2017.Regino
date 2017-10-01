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
    /// <summary>
    /// Class for account logic on website: login,registration, captcha
    /// </summary>
    [Authorize]
    public class AccountController : Controller
    {
        private readonly IUserService userService;
        private readonly IProfileService profileService;

        /// <summary>
        /// Creates an account controller
        /// </summary>
        public AccountController(IUserService userService, IProfileService profileService)
        {
            this.userService = userService;
            this.profileService = profileService;
        }


        /// <summary>
        /// Get method for login
        /// </summary>
        /// <param name="returnUrl">Url to redirect after login</param>
        /// <returns>Page of login form</returns>
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

        /// <summary>
        /// Post method for login
        /// </summary>
        /// <param name="loginModel">Login model.</param>
        /// <param name="returnUrl">Url to redirect after login</param>
        /// <returns>Homepage or banned page</returns>
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

        /// <summary>
        /// Get method for registration
        /// </summary>
        /// <returns>Page of registration form</returns>
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


        /// <summary>
        /// Post method for registration
        /// </summary>
        /// <param name="registrationModel">Registration model</param>
        /// <returns>Homepage</returns>
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

        /// <summary>
        /// Method to log out
        /// </summary>
        /// <returns>Strat page</returns>
        [HttpGet]
        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }

        /// <summary>
        /// Method for creatin captha
        /// </summary>
        /// <returns>ActionResult</returns>
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