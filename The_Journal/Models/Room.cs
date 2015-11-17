using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity.Spatial;

namespace The_Journal.Models
{
    //public enum RoomName { Baby, Toddlers, PreSchool }

    public class Room
    {
        [Key]
        public int RoomID { get; set; }

        public string Name { get; set; }

        [Display(Name = "Maximum Number")]
        public int MaxNum { get; set; }

        public virtual IEnumerable<Child> Children { get; set; }

    //    public int NumofChildred { get { return this.Children.Count(); } }
    }

}