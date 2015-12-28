using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using System.Web.Helpers;


namespace StatusReportingApp.Controllers
{
    

    public class TestController : Controller
    {
        DataAccessLayer.Entity.EmidsIHStatEntities db = new DataAccessLayer.Entity.EmidsIHStatEntities();
        public ActionResult Index()
        {
            DataAccessLayer.DataAccessLogic.GetDailyTeamRecord acc = new DataAccessLayer.DataAccessLogic.GetDailyTeamRecord();
            var newtbl = acc.getcall();
            return View();
        }

        public ActionResult GetRecordsByGroup()
        {
            int gid = int.Parse(Session["GroupID"].ToString());
            
            var tbldev = db.StatusReports.Where(x => x.UserData.GroupID == 1).Select(x => x).ToList();
            var tblqa = db.StatusReports.Where(x => x.UserData.GroupID == 2).Select(x => x).ToList();
            var tblba = db.StatusReports.Where(x => x.UserData.GroupID == 3).Select(x => x).ToList();
            var tbldatedevuser = db.StatusReports.Where(x => x.UserID == 6001 && x.Timestamp >= DateTime.Today && x.Timestamp <= DateTime.Today);
            return View(tbldatedevuser);
        }

        public ActionResult GetExcelWithGrid(IEnumerable<DataAccessLayer.Entity.StatusReport> tbl)
        {
            DataAccessLayer.Entity.EmidsIHStatEntities db = new DataAccessLayer.Entity.EmidsIHStatEntities();
            var RoleTable = db.Roles.ToList();
            WebGrid wd = new WebGrid(source: RoleTable, canSort: false);
            string gridData = wd.GetHtml(tableStyle: "table table-striped", columns: wd.Columns(
                wd.Column(columnName: "RoleID", header: "Role ID"),
                wd.Column(columnName: "RoleName", header: "Role Type")
                )).ToString();
            Response.ClearContent();
            Response.AddHeader("content-disposition", "attachment; filename=StudentMarksDetails.xls");
            Response.ContentType = "application/excel";
            Response.Write(gridData);
            Response.End();
            return RedirectToAction("EmpData", "Export");

        }

        public ActionResult SetNewPassword()
        {
            return View();

        }

        [HttpPost]
        public ActionResult ChangePassword(Models.PasswordData pwdObj)
        {
            int uid = int.Parse(Session["UserID"].ToString());
            var db = new DataAccessLayer.Entity.EmidsIHStatEntities();
            int stat = int.Parse(db.ChangePassword(uid,pwdObj.Password).ToString());
            return View();
        }

        public ActionResult TestUI()
        {
            return View();
        }
    }
}
