using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace The_Journal.ViewModels
{
    public class StatusViewModel
    {
        public StatusViewModel()
        {
            ValidationErrors= new List<string>();
        }

        public bool IsSuccessful { get; set; }

        public List<string> ValidationErrors { get; set; }
    }
}