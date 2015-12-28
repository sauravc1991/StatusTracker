using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StatusReportingApp.Controllers
{
    public class ErrorController : Controller
    {
        /// <summary>
        /// This action represents the error page
        /// </summary>
        /// <param name="Message">Error message to be displayed (provided via querystring parameter - a design choice)</param>
        /// <returns></returns>
        public ActionResult Index(string Message)
        {
            // We choose to use the ViewBag to communicate the error message to the view
            ViewBag.Message = Message;
            return View();
        }

    }
}
