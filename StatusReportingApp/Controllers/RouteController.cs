using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StatusReportingApp.Controllers
{
    public class RouteController : Controller
    {
        //
        // GET: /Route/

        public ActionResult RouteUser()
        {
            int UserID = int.Parse(Session["UserID"].ToString());
            string Name = Session["Name"].ToString();
            int GroupID = int.Parse(Session["GroupID"].ToString());
            int RoleID = int.Parse(Session["RoleID"].ToString());
            if (RoleID == 1)
            {
                switch (GroupID)
                {
                    case 1:
                        //Dev Admin                             
                        return RedirectToAction("DevAdmin", "DevOperations");
                        break;

                    case 2:
                        //QA Admin
                        return RedirectToAction("QAAdmin", "QAOperations");
                        break;

                    case 3:
                        //BA Admin
                        return RedirectToAction("BAAdmin", "BAOperations");
                        break;
                }
            }

            else if (RoleID == 2)
            {
                switch (GroupID)
                {
                    case 1:
                        //Dev User
                        return RedirectToAction("DevUser", "DevOperations");
                        break;

                    case 2:
                        //QA User
                        return RedirectToAction("QAUser", "QAOperations");
                        break;

                    case 3:
                        //BA User
                        return RedirectToAction("BAUser", "BAOperations");
                        break;
                }
            }
            else if (RoleID == 3)
            {
                if (GroupID == 4)
                    return RedirectToAction("LandingPage", "Admin");
            }
            return View();
        }

    }
}
