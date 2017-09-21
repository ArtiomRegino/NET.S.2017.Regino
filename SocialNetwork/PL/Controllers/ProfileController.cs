using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PL.Controllers
{
    public class ProfileController : Controller
    {
        
        [Authorize]
        [HttpGet]
        public ActionResult Index()
        {
            return View("_ProfileWall");
        }

        [Authorize]
        [HttpGet]
        public ActionResult Search()
        {
            return View("_ProfileWall");
        }
    }
}