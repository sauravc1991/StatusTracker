using System;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Helpers;
using System.Web.UI;

namespace StatusReportingApp.Controllers
{
    public class AdminController : Controller
    {
        DataAccessLayer.Entity.EmidsIHStatEntities db = new DataAccessLayer.Entity.EmidsIHStatEntities();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult MasterUser()
        {
            return View();
        }
        public ActionResult LandingPage()
        {
            return View();
        }
        [HttpGet]
        public ActionResult GetDate()
        {
            return View();
        }

        [HttpPost]
        public ActionResult GetRecordsByDate(Models.DatePicker ob)
        {
            int gid = int.Parse(ob.GroupID.ToString());
            IEnumerable<DataAccessLayer.Entity.StatusReport> rec = db.StatusReports.Where(x => x.UserData.GroupID == gid && x.Timestamp >= ob.Start && x.Timestamp <= ob.End).Select(x => x).ToList();
            ViewBag.Start = ob.Start;
            ViewBag.End = ob.End;
            return View(rec);
        }
    }
}
