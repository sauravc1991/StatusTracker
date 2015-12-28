namespace DataAccessLayer.DataAccessLogic
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Data;


    public class GetDailyTeamRecord
    {
        DataAccessLayer.Entity.EmidsIHStatEntities db = new Entity.EmidsIHStatEntities();
        public IEnumerable<DataAccessLayer.Entity.StatusReport>  getcall()
        {
            var tbl = db.StatusReports.Where(x => x.Timestamp==DateTime.Today).Select(x => x);
            return tbl.ToList();

        }
    }
}
