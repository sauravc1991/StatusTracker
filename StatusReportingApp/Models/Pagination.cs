using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StatusReportingApp.Models
{
    public class Pagination
    {

        public IEnumerable<DataAccessLayer.Entity.StatusReport> Reports { get; set; }
        public DateTime datepointer { get; set; }

    }
}