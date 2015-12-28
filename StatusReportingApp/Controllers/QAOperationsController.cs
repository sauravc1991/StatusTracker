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
    public class QAOperationsController : Controller
    {
        private DataAccessLayer.Entity.EmidsIHStatEntities db = new DataAccessLayer.Entity.EmidsIHStatEntities();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult QAUser()
        {
            int uid = Convert.ToInt32(Session["UserID"]);
            DataAccessLayer.DataAccessLogic.GetRecord GetRes = new DataAccessLayer.DataAccessLogic.GetRecord();
            IEnumerable<DataAccessLayer.Entity.StatusReport> resTable = GetRes.GetRecordForCurrent(uid).ToList();
            return View(resTable);
        }

        public ActionResult QAAdmin()
        {
            int gid = Convert.ToInt32(Session["GroupID"]);
            DataAccessLayer.DataAccessLogic.GetTeamRecord GetRes = new DataAccessLayer.DataAccessLogic.GetTeamRecord();
            IEnumerable<DataAccessLayer.Entity.GetCurrentTeamRecord_Result> resTable = GetRes.GetTeamRecordForCurrent(gid).ToList();
            return View(resTable);
        }

        //DATE OPERATIONS
        [HttpGet]
        public ActionResult GetDate()
        {
            return View();
        }

        [HttpPost]
        public ActionResult GetRecordsByDate(Models.DatePicker ob)
        {
            int uid = Convert.ToInt32(Session["UserID"]);
            IEnumerable<DataAccessLayer.Entity.StatusReport> rec = db.StatusReports.Where(x => x.UserID == uid && x.Timestamp >= ob.Start && x.Timestamp <= ob.End).Select(x => x).ToList();
            ViewBag.Start = ob.Start;
            ViewBag.End = ob.End;
            return View(rec);
        }


        //ALL CRUD OPERATIONS ON QA
        //Edit
        public ActionResult Edit(int id = 0)
        {
            StatusReport statusreport = db.StatusReports.Single(s => s.SerialNumber == id);
            if (statusreport == null)
            {
                return HttpNotFound();
            }
            return View(statusreport);
        }



        [HttpPost]
        public ActionResult Edit(StatusReport statusreport)
        {
            if (ModelState.IsValid)
            {
                db.StatusReports.Attach(statusreport);
                db.ObjectStateManager.ChangeObjectState(statusreport, EntityState.Modified);
                db.SaveChanges();
                if (int.Parse(Session["RoleID"].ToString()) == 2)
                    return RedirectToAction("QAUser");
                else if ((int.Parse(Session["RoleID"].ToString()) == 1))
                    return RedirectToAction("QAAdmin");

            }
            return View(statusreport);
        }


        //Details
        public ActionResult Details(int id = 0)
        {
            StatusReport statusreport = db.StatusReports.Single(s => s.SerialNumber == id);
            if (statusreport == null)
            {
                return HttpNotFound();
            }
            return View(statusreport);
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }

    }
}
