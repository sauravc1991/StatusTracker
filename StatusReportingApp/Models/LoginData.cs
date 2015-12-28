using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace StatusReportingApp.Models
{
    public class LoginData
    {
        [Required(ErrorMessage = "  UserName is Required")]
        public string UserID { get; set; }

        [Required(ErrorMessage = "  Password is Required")]
        public string  Password { get; set; }
    }
}