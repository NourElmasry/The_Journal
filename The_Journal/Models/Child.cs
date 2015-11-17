using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity.Spatial;

namespace The_Journal.Models
{
   

    public class Child
    {
        [Key]
        public int ChildID { get; set; }

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

        public int Age { get; set; }

        [Display(Name = "Start Date")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        [DataType(DataType.DateTime)]
        public DateTime StartDate { get; set; }

        [Display(Name = "End Date")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        [DataType(DataType.DateTime)]
        public DateTime? EndDate { get; set; }

        public string SEN { get; set; }

        public int FamilyID { get; set; }
        public virtual Family Family { get; set; }

        [Display(Name = "Key Worker")]
        public int EmployeeID { get; set; }
        public virtual Employee KeyWorker { get; set; }

        public int RoomID { get; set; }
        public virtual Room Room { get; set; }

        public string Allergy { get; set; }

    }
}