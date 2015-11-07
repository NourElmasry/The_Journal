using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity.Spatial;

namespace The_Journal.Models
{
    //public enum SessionDay { Monday, Tuesday, Wednesday, Thursday, Friday }
    //public enum SessionType { Morning, Afternoon, [Display(Name = "Full Day")] FullDay }

    public class Session
    {
        [Key]
        public int SessionID { get; set; }

        public string Type { get; set; }

        public int SessionRate { get; set; }

        public string Day { get; set; }
    }
}