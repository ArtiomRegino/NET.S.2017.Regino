using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using BLL.Interfaces.Interfaces;
using PL.Infrastructure;
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
        [Authorize]
        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }

        //В сессии создаем случайное число от 1111 до 9999.
        //Создаем в ci объект CatchaImage
        //Очищаем поток вывода
        //Задаем header для mime-типа этого http-ответа будет "image/jpeg" т.е. картинка формата jpeg.
        //Сохраняем bitmap в выходной поток с форматом ImageFormat.Jpeg
        //Освобождаем ресурсы Bitmap
        //Возвращаем null, так как основная информация уже передана в поток вывод
        [AllowAnonymous]
        public ActionResult Captcha()
        {
            Session[CaptchaImage.CaptchaValueKey] =
                new Random(DateTime.Now.Millisecond).Next(1111, 9999).ToString(CultureInfo.InvariantCulture);
            var ci = new CaptchaImage(Session[CaptchaImage.CaptchaValueKey].ToString(), 211, 50, "Helvetica");

            // Change the response headers to output a JPEG image.
            this.Response.Clear();
            this.Response.ContentType = "image/jpeg";

            // Write the image to the response stream in JPEG format.
            ci.Image.Save(this.Response.OutputStream, ImageFormat.Jpeg);

            // Dispose of the CAPTCHA image object.
            ci.Dispose();
            return null;
        }
    }
}