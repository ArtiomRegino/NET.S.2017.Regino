using System.Web.Mvc;

namespace PL.Controllers
{
    /// <summary>
    /// Class for start action.
    /// </summary>
    public class HomeController : Controller
    {
        /// <summary>
        /// Start action of website
        /// </summary>
        /// <returns>Start page</returns>
        [HttpGet]
        public ActionResult Index()
        {
            if (User.Identity.IsAuthenticated)
                return RedirectToAction("Index", "Profile");

            return RedirectToAction("Login", "Account");
        }
    }
}