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
    public class TaskController : Controller
    {
        private EmidsIHStatEntities db = new EmidsIHStatEntities();

        //
        // GET: /Task/

        public ActionResult Index()
        {
            return View(db.StatusReports.ToList());
        }

        //
        // GET: /Task/Details/5

        public ActionResult Details(int id = 0)
        {
            StatusReport statusreport = db.StatusReports.Single(s => s.SerialNumber == id);
            if (statusreport == null)
            {
                return HttpNotFound();
            }
            return View(statusreport);
        }

        //
        // GET: /Task/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Task/Create

        [HttpPost]
        public ActionResult Create(StatusReport statusreport)
        {
            if (ModelState.IsValid)
            {
                db.StatusReports.AddObject(statusreport);
                db.SaveChanges();
                return RedirectToAction("RouteUser", "Route");

            }

            return View(statusreport);
        }

        //
        // GET: /Task/Edit/5

        public ActionResult Edit(int id = 0)
        {
            StatusReport statusreport = db.StatusReports.Single(s => s.SerialNumber == id);
            if (statusreport == null)
            {
                return HttpNotFound();
            }
            return View(statusreport);
        }

        //
        // POST: /Task/Edit/5

        [HttpPost]
        public ActionResult Edit(StatusReport statusreport)
        {
            if (ModelState.IsValid)
            {
                db.StatusReports.Attach(statusreport);
                db.ObjectStateManager.ChangeObjectState(statusreport, EntityState.Modified);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(statusreport);
        }

        //
        // GET: /Task/Delete/5

        public ActionResult Delete(int id = 0)
        {
            StatusReport statusreport = db.StatusReports.Single(s => s.SerialNumber == id);
            if (statusreport == null)
            {
                return HttpNotFound();
            }
            return View(statusreport);
        }

        //
        // POST: /Task/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            StatusReport statusreport = db.StatusReports.Single(s => s.SerialNumber == id);
            db.StatusReports.DeleteObject(statusreport);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}