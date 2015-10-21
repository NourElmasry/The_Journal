using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity.Spatial;

namespace The_Journal.Models
{
    public enum MealType { Breakfast, Snack, Tea, Pudding, Dinner }
    public enum Portion
    {
        Nothing,
        [Display(Name = "Some of It")]
        SomeofIt,
        [Display(Name = "Most of It")]
        MostofIt,
        [Display(Name = "All of It")]
        AllofIt
    }
    public class DayJournal
    {
        [Key]
        public int DayJournalID { get; set; }

        public int ChildID { get; set; }
        public virtual Child Sibiling { get; set; }

        [Display(Name = "Meal Type")]
        public MealType? MealType { get; set; }

        [Display(Name = "Meal Name")]
        public string MealName { get; set; }

        [Display(Name = "Portion Eaten")]
        public Portion? Portion { get; set; }

        [Display(Name = "Fell asleep")]
        [DataType(DataType.DateTime)]
        public DateTime? NapStart { get; set; }

        [Display(Name = "Woke up")]
        [DataType(DataType.DateTime)]
        public DateTime? NapEnd { get; set; }

        public string Note { get; set; }

    }
}