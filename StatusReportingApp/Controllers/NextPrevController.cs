using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StatusReportingApp.Controllers
{
    public class NextPrevController : Controller
    {
        public ActionResult Index()
        {
            DataAccessLayer.Entity.EmidsIHStatEntities db = new DataAccessLayer.Entity.EmidsIHStatEntities();
            IEnumerable<DataAccessLayer.Entity.StatusReport> tbl = db.StatusReports.Where(x => x.Timestamp == DateTime.Today).Select(x => x).ToList();
            return View();
        }

        [HttpPost]
        public ActionResult Index(string id)
        {

            return View();
        }



    }
}
