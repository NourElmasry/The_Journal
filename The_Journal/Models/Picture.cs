using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity.Spatial;

namespace The_Journal.Models
{
    public class Picture
    {
        [Key]
        public int PicID { get; set; }

        public byte[] Pic { get; set; }

        public int ChildID { get; set; }
        public virtual Child Child { get; set; }

        [DataType(DataType.MultilineText)]
        public string PicDescription { get; set; }
    }
}