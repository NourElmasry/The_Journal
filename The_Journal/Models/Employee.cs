using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity.Spatial;

namespace The_Journal.Models
{
   // public enum Type { Admin, Nurse }
    public class Employee
    {
        [Key]
        public int EmployeeID { get; set; }

        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Display(Name = "Known Name")]
        public string KnownName { get; set; }

        public string Gender { get; set; }

        [Display(Name = "Date of Birth")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        [DataType(DataType.DateTime)]
        public DateTime DOB { get; set; }

        [Display(Name = "Start Date")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        [DataType(DataType.DateTime)]
        public DateTime StartDate { get; set; }

        [Display(Name = "End Date")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        [DataType(DataType.DateTime)]
        public DateTime? EndDate { get; set; }

        public int RoomID { get; set; }
        public virtual Room Room { get; set; }

        public string Type { get; set; }

        public int Salary { get; set; }

        public Session Session { get; set; }

        [Display(Name = "Mobile Number")]
        public int MobileNum { get; set; }

        [Display(Name = "Other Number")]
        public int OtherNum { get; set; }

        public string Address { get; set; }
    }
}