using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataAccessLayer.Entity;



namespace StatusReportingApp.Controllers
{

    public class AccountManagementController : Controller
    {
        private EmidsIHStatEntities db = new EmidsIHStatEntities();
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(Models.LoginData dataObj)
        {
            DataAccessLayer.DataAccessLogic.LoginRepository doLogin = new DataAccessLayer.DataAccessLogic.LoginRepository();
            var res = doLogin.ValidateLogin(dataObj.UserID, dataObj.Password);
            if (res!=null)
            {
                int UserID = Convert.ToInt32(res[0]);
                string Name = res[1].ToString();
                int GroupID = Convert.ToInt32(res[2]);
                int RoleID = Convert.ToInt32(res[3]);
                Session["UserID"] = res[0];
                Session["Name"] = res[1];
                Session["GroupID"] = res[2];
                Session["RoleID"] = res[3];

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
               

            }

            return RedirectToAction("LoginError");
        }

        public ActionResult Logout()
        {
            Session.Abandon();
            return RedirectToAction("Index");
        }

        

        public ActionResult LoginError()
        {
            return View();
        }

        
    }
}
