using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NLog;

namespace PL.Controllers
{
    /// <summary>
    /// Class for error logic. Returns various error pages
    /// </summary>
    public class ErrorController : Controller
    {
        private static readonly Logger logger = LogManager.GetCurrentClassLogger();

        /// <summary>
        /// Returns error page
        /// </summary>
        public ViewResult Index()
        {
            logger.Info("Forbidden action");
            return View("Error");
        }

        /// <summary>
        /// Returns NotFound error page
        /// </summary>
        public ViewResult NotFound()
        {
            logger.Info("Page not found");
            Response.StatusCode = 404;
            return View("NotFoundView");
        }
    }
}