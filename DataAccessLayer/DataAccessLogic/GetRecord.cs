namespace DataAccessLayer.DataAccessLogic
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    
    public class GetRecord
    {
        protected DataAccessLayer.Entity.EmidsIHStatEntities myDataContext;

        public GetRecord()
        {
            myDataContext = new Entity.EmidsIHStatEntities();
        }

        public IEnumerable<DataAccessLayer.Entity.StatusReport> GetRecordForCurrent(int UserID)
        {
            IEnumerable<DataAccessLayer.Entity.StatusReport> res=myDataContext.GetCurrentRecord(UserID);
            return res;
        }
    }

}
