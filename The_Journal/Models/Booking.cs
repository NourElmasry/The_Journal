using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity.Spatial;

namespace The_Journal.Models
{
    public class Booking
    {
        [Key]
        public int BookingID { get; set; }

        public int ChildID { get; set; }
        public virtual Child Child { get; set; }

        public IEnumerable<Session> Sessions { get; set; }

        public string Room { get; set; }
       

    }
}