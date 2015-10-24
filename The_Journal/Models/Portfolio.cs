using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity.Spatial;

namespace The_Journal.Models
{
    public class Portfolio
    {
        [Key]
        public int PortfolioID { get; set; }

        public int ChildID { get; set; }
        public virtual Child Child { get; set; }

        public IEnumerable<DayJournal> Journal { get; set; }

        public IEnumerable<Picture> Pics { get; set; }

        [DataType(DataType.MultilineText)]
        public string Note { get; set; }
    }
}