using System.ComponentModel.DataAnnotations;

namespace KOTApp.Models
{
    public class Company
    {
        [Key] 
        public int CompanyId { get; set; }


        [Required]
        [Display(Name = "Company Name")]
        public string CompanyName { get; set; } = "My Company";

        [Display(Name = "Company Address")]
        public string CompanyAddress { get; set; } = "";


        public int CompanyOwnerId { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = false, DataFormatString = "{0:C2}")]
        public decimal CompanyOwnerPercent { get; set; }


        [DisplayFormat(ApplyFormatInEditMode = false, DataFormatString = "{0:C2}")]
        public decimal EmployeeAdvancePercent { get; set; }


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

        public CompanyOwner? CompanyOwner { get; set; }
    }
}