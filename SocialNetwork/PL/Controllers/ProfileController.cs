using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PL.Controllers
{
    public class ProfileController : Controller
    {
        // GET: Profile
        [Authorize]
        public ActionResult Index()
        {
            return View("_ProfileWall");
        }
    }
}