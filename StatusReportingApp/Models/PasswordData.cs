using System;
using System.ComponentModel.DataAnnotations;
using System.Web.Security;
using CompareAttribute = System.Web.Mvc.CompareAttribute;

namespace StatusReportingApp.Models
{
    public class PasswordData
    {
       

        [Required]
        public string Password { get; set; }

        [Compare("Password",ErrorMessage="The entered passwords do not match")]
        public string ConfirmPassword { get; set; }

    }
}