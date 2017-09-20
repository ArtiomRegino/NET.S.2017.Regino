﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace PL.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            if (User.Identity.IsAuthenticated)
            {
                if (User.IsInRole("Banned"))
                {
                    
                }
                FormsAuthentication.SignOut();
                return RedirectToAction("Index", "Profile");
            }

            return RedirectToAction("Login", "Account");
        }

    }
}