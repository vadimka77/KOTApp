using System.ComponentModel.DataAnnotations;

namespace KOTApp.Models
{
    public enum WorkTimeFrame {
        [Display(Name ="Week")]
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

    public class Company
    {
        [Key] 
        public int CompanyId { get; set; }

        [Required]
        [Display(Name ="Company Name")]
        public string CompanyName { get; set; }

        [Display(Name ="Company Address")]
        public string CompanyAddress { get; set; }

        public WorkTimeFrame PaymentTimeFrame { get; set; }

        [Required]
        [Display(Name ="Current Time Frame Start")]
        [DataType(DataType.DateTime)]
        public DateTime CurrentTFStart { get; set; }

        [Required]
        [Display(Name ="Current Time Frame End")]
        [DataType(DataType.DateTime)]
        public DateTime CurrentTFEnd { get; set; }

        ICollection<Contract> Contracts { get; set; }
        ICollection<Employee> Employees { get; set; }

        public int CompanyOwnerId { get; set; }
        public CompanyOwner? CompanyOwner { get; set; }
    }
}