using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity.Spatial;

namespace The_Journal.Models
{
    public class Invoice
    {
        [Key]
        public int InvoiceID { get; set; }
        
        [DataType(DataType.DateTime)]
        public DateTime StartDate { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime EndDate { get; set; }

        public int Total { get; set; }

        public IEnumerable<InvoiceLine> InvoiceLines { get; set; }

        public int FamilyID { get; set; }
        public virtual Family Family { get; set; }
    }
}