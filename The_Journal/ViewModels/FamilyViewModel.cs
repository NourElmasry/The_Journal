using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;    
using System.Data.Entity.Spatial;
using System.ComponentModel.DataAnnotations.Schema;
using The_Journal.Models;

namespace The_Journal.ViewModels
{
    public class FamilyViewModel
    {
        [Key]
        public int FamilyID { get; set; }

        // Carer Information
        
        public int CarerID { get; set; }

        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Display(Name = "Date of Birth")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime DOB { get; set; }

        [Display(Name = "Home Number")]
        public int HomeNum { get; set; }

        [Display(Name = "Work Number")]
        public int WorkNum { get; set; }

        [Display(Name = "Mobile Number")]
        public int MobileNum { get; set; }



        public string Address { get; set; }

        public string PostCode { get; set; }

       // bool IsMainCarer { get { return Family.MainCarerID == this.CarerID; } }

        //Emergency Contact Information

       
        public int EmergencyContactID { get; set; }

        [Display(Name = "First Name")]
        public string EmFirstName { get; set; }

        [Display(Name = "Last Name")]
        public string EmLastName { get; set; }

        [Display(Name = "Mobile Number")]
        public int EmMobileNum { get; set; }

        [Display(Name = "Relationship")]
        public string EmRelationship { get; set; }

    }
}