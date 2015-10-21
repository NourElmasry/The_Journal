using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;

namespace The_Journal.Models
{

    public class Event
    {
        [Key]
        public int EventID { get; set; }

        public string Description { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime StartDate { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime EndDate { get; set; }

        public int? ChildID { get; set; }
        public virtual Child Child { get; set; }

        public int? EmployeeID { get; set; }
        public virtual Employee Employee { get; set; }


    }
}