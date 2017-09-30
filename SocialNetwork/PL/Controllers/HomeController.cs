using System.Web.Mvc;

namespace PL.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            if (User.Identity.IsAuthenticated)
                return RedirectToAction("Index", "Profile");

            return RedirectToAction("Login", "Account");
        }
    }
}