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
    public class UserController : Controller
    {
        private EmidsIHStatEntities db = new EmidsIHStatEntities();

        public ActionResult Index()
        {
            var userdatas = db.UserDatas.Include("Group").Include("Role").Where(x=>x.RoleID!=3).Select(x=>x);
            return View(userdatas.ToList());
        }

        public ActionResult Details(int id = 0)
        {
            UserData userdata = db.UserDatas.Single(u => u.UserID == id);
            if (userdata == null)
            {
                return HttpNotFound();
            }
            return View(userdata);
        }
        
        public ActionResult Create()
        {
            ViewBag.GroupID = new SelectList(db.Groups, "GroupID", "GroupName");
            ViewBag.RoleID = new SelectList(db.Roles, "RoleID", "RoleName");
            return View();
        }

       
        [HttpPost]
        public ActionResult Create(UserData userdata)
        {
            if (ModelState.IsValid)
            {
                db.UserDatas.AddObject(userdata);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.GroupID = new SelectList(db.Groups, "GroupID", "GroupName", userdata.GroupID);
            ViewBag.RoleID = new SelectList(db.Roles, "RoleID", "RoleName", userdata.RoleID);
            return View(userdata);
        }
        
        public ActionResult Edit(int id = 0)
        {
            UserData userdata = db.UserDatas.Single(u => u.UserID == id);
            if (userdata == null)
            {
                return HttpNotFound();
            }
            ViewBag.GroupID = new SelectList(db.Groups, "GroupID", "GroupName", userdata.GroupID);
            ViewBag.RoleID = new SelectList(db.Roles, "RoleID", "RoleName", userdata.RoleID);
            return View(userdata);
        }

        [HttpPost]
        public ActionResult Edit(UserData userdata)
        {
            if (ModelState.IsValid)
            {
                db.UserDatas.Attach(userdata);
                db.ObjectStateManager.ChangeObjectState(userdata, EntityState.Modified);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.GroupID = new SelectList(db.Groups, "GroupID", "GroupName", userdata.GroupID);
            ViewBag.RoleID = new SelectList(db.Roles, "RoleID", "RoleName", userdata.RoleID);
            return View(userdata);
        }

        public ActionResult Delete(int id = 0)
        {
            UserData userdata = db.UserDatas.Single(u => u.UserID == id);
            if (userdata == null)
            {
                return HttpNotFound();
            }
            return View(userdata);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            UserData userdata = db.UserDatas.Single(u => u.UserID == id);
            db.UserDatas.DeleteObject(userdata);
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