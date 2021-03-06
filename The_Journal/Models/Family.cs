﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity.Spatial;

namespace The_Journal.Models
{
    public class Family
    {
        [Key]
        public int FamilyID { get; set; }

        public string FamilyName { get; set; }

        public string ApplicationUserID { get; set; }
        public virtual ApplicationUser Account { get; set; } 

        public int MainCarerID { get; set; }
        //public virtual Carer MainCarer { get; set; }

        public virtual IEnumerable<Child> Children { get; set; }
        public virtual IEnumerable<Carer> Carers { get; set; }
        public virtual IEnumerable<EmergencyContact> EmergencyContacts { get; set; }
    }
}