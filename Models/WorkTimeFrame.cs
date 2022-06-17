using System.ComponentModel.DataAnnotations;

namespace KOTApp.Models
{
    public enum WorkTimeFrame
    {
        [Display(Name = "Week")]
        Week,

        [Display(Name = "Two Weeks")]
        TwoWeeks,

        [Display(Name = "Month")]
        Month,

        [Display(Name = "Two Months")]
        TwoMonths,

        [Display(Name = "Quarter")]
        Quarter,

        [Display(Name = "Year")]
        Year
    }
}
