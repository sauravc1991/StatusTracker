namespace DataAccessLayer.DataAccessLogic
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class GetTeamRecord
    {
        protected DataAccessLayer.Entity.EmidsIHStatEntities myDataContext;

        public GetTeamRecord()
        {
            myDataContext = new Entity.EmidsIHStatEntities();
        }

        public IEnumerable<DataAccessLayer.Entity.GetCurrentTeamRecord_Result> GetTeamRecordForCurrent(int GroupID)
        {
            IEnumerable<DataAccessLayer.Entity.GetCurrentTeamRecord_Result> res = myDataContext.GetCurrentTeamRecord(GroupID);
            return res; 
        }
    }
}
