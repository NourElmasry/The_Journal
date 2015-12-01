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

        public List<EContactViewModel> EContacts { get; set; }

        public List<CarerViewModel> Carers { get; set; }

        public List<ChildViewModel> Children { get; set; }
    }

    public class ChildViewModel
    {
        [Key]
        public int ChildID { get; set; }

        [Display(Name = "First Name")]
        public string ChildFirstName { get; set; }

        [Display(Name = "Last Name")]
        public string ChildLastName { get; set; }

        [Display(Name = "Known Name")]
        public string ChildKnownName { get; set; }

        public string Gender { get; set; }

        [Display(Name = "Date of Birth")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        [DataType(DataType.DateTime)]
        public DateTime ChildDOB { get; set; }

        public int ChildAge { get; set; }

        [Display(Name = "Start Date")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        [DataType(DataType.DateTime)]
        public DateTime ChildStartDate { get; set; }

        [Display(Name = "End Date")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        [DataType(DataType.DateTime)]
        public DateTime? ChildEndDate { get; set; }

        public string ChildSEN { get; set; }

        public int FamilyID { get; set; }
        public virtual Family Family { get; set; }

        [Display(Name = "Key Worker")]
        public int EmployeeID { get; set; }
        public virtual Employee ChildKeyWorker { get; set; }

        public int RoomID { get; set; }
        public virtual Room ChildRoom { get; set; }

      //  public string ChildRoom { get; set; }

        public string ChildAllergy { get; set; }
    }

    public class CarerViewModel
    {
        // Carer Information
        
        public int CarerID { get; set; }

        [Display(Name = "First Name")]
        public string CFirstName { get; set; }

        [Display(Name = "Last Name")]
        public string CLastName { get; set; }

        [Display(Name = "Date of Birth")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime CDOB { get; set; }

        [Display(Name = "Email")]
        public string CEmail { get; set; }

        [Display(Name = "Home Number")]
        public int CHomeNum { get; set; }

        [Display(Name = "Work Number")]
        public int CWorkNum { get; set; }

        [Display(Name = "Mobile Number")]
        public int CMobileNum { get; set; }

        [Display(Name = "Address")]
        public string CAddress { get; set; }

        [Display(Name = "Postcode")]
        public string CPostCode { get; set; }

        public bool CMainCarer { get; set; }
       
    }

    //Emergency Contact Information
    public class EContactViewModel
    {
       
        public int EmergencyContactID { get; set; }

        [Display(Name = "First Name")]
        public string ECFirstName { get; set; }

        [Display(Name = "Last Name")]
        public string ECLastName { get; set; }

        [Display(Name = "Mobile Number")]
        public int ECMobileNum { get; set; }

        [Display(Name = "Relationship")]
        public string ECRelationship { get; set; }

    }
}