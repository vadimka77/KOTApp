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
        [DisplayFormat(ApplyFormatInEditMode = false, DataFormatString = "{0:yyyy-MM-dd}")]
        [DataType(DataType.DateTime)]
        public DateTime CurrentTFStart { get; set; }

        [Required]
        [Display(Name ="Current Time Frame End")]
        [DisplayFormat(ApplyFormatInEditMode = false, DataFormatString = "{0:yyyy-MM-dd}")]
        [DataType(DataType.DateTime)]
        public DateTime CurrentTFEnd { get; set; }

        public ICollection<Contract>? Contracts { get; set; }
        public ICollection<Employee>? Employees { get; set; }

        public int CompanyOwnerId { get; set; }
        public int CompanyOwnerPay { get; set; }
        public CompanyOwner? CompanyOwner { get; set; }
    }
}