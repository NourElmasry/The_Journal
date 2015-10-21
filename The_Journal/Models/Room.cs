using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity.Spatial;

namespace The_Journal.Models
{
    public enum RoomName { Baby, Toddlers, PreSchool }

    public class Room
    {
        [Key]
        public int RoomID { get; set; }

        public RoomName Name { get; set; }

        [Display(Name = "Maximum Number")]
        public int MaxNum { get; set; }

        [Display(Name = "Number of Children")]
        public int NumofChildren { get; set; }

    }

}