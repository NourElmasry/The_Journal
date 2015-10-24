using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity.Spatial;

namespace The_Journal.Models
{
    public class EmergencyContact
    {
        [Key]
        public int EmergencyContactID { get; set; }

        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Display(Name = "Mobile Number")]
        public int MobileNum { get; set; }

        [Display(Name = "Relationship")]
        public string Relationship { get; set; }

        public int FamilyID { get; set; }
        public virtual Family Family { get; set; }
    }
}