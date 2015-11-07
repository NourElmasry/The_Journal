using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity.Spatial;

namespace The_Journal.Models
{
    public class InvoiceLine
    {
        [Key]
        public int InvoiceLineID { get; set; }

        public int ChildID { get; set; }
        public virtual Child Child { get; set; }

        public int Amount { get; set; }

        public DateTime SessionDate { get; set; }

        public int InvoiceID { get; set; } 
    }
}