using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KOTApp.Models
{
    public class Contract
    {
        // Sorting Tomorrow

        [Key]
        public int ContractId { get; set; }

        public int CompanyId { get; set; }
        public int EmployeeID { get; set; }

        [Display(Name ="Advance Percent")]
        [DisplayFormat(ApplyFormatInEditMode = false, DataFormatString = "{0:C2}")]
        public decimal AdvancePercent { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = false, DataFormatString = "{0:C2}")]
        public decimal AdvanceAmount { get; set; } 

        [Display(Name = "Completion Certificate")]
        public string CompletionCertificate { get; set; }

        [Display(Name = "Contract Name")]
        public string ContractName { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        [Display(Name = "Contract Date")]
        public DateTime ContractDate { get; set; }

        [DataType(DataType.DateTime)]
        [Display(Name = "Close Date")]
        public DateTime? CloseDate { get; set; }

        [Required]
        [Column(TypeName = "money")]
        [Display(Name = "Contract Amount")]
        public decimal ContractAmount { get; set; }

        [Required]
        [Display(Name = "Company Owner Amount")]
        public int CompanyOwnerAmount { get; set; }

        public int CompanyOwnerPercent { get; set; }

        [Display(Name ="Change Orders Total")]
        public decimal COTotal { get; set; }

        [Display(Name ="Cost")]
        public decimal Cost { get; set; }

        [Display(Name = "NET Sale")]
        public decimal NETSale { get; set; }

        [Display(Name = "Gross Profit")]
        public decimal GrossProfit { get; set; }

        public decimal EmpCommAmount { get; set; }

        public decimal EmpCommPercent { get; set; }

        public decimal EmpBalanceAmount { get; set; }

        public Employee? Employee { get; set; }
        public Company? Company { get; set; }
    }
}