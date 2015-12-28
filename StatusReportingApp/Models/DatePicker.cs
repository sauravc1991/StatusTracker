using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace StatusReportingApp.Models
{
    public class DatePicker
    {
        [Required]
        public DateTime Start { get; set; }

        [Required]
        public DateTime End { get; set; }

        [Required]
        //public IEnumerable<DataAccessLayer.Entity.Group> GroupID { get; set; }
        public int GroupID { get; set; }

    }
}