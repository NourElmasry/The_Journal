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

        public string ApplicationUserID { get; set; }
        public virtual ApplicationUser Account { get; set; }

        public List<EmergencyContact> EmergencyContacts { get; set; }

        public List<Child> Children { get; set; }

        public List<Carer> Carers { get; set; }

        public Carer MainCarer { get; set; }
    }
}