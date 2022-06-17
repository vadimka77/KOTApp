using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KOTApp.Models
{
    public class Contract
    {
        [Key]
        public int ContractId { get; set; }


        [Display(Name = "Contract Name")]
        public string ContractName { get; set; }

        [Display(Name = "Completion Certificate")]
        public string CompletionCertificate { get; set; }


        [Required]
        [Column(TypeName = "money")]
        [Display(Name = "Contract Amount")]
        public decimal ContractAmount { get; set; }

        [Display(Name = "Advance Percent")]
        [DisplayFormat(ApplyFormatInEditMode = false, DataFormatString = "{0:C2}")]
        public decimal AdvancePercent { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = false, DataFormatString = "{0:C2}")]
        public decimal AdvanceAmount { get; set; }

        [Display(Name = "Change Orders Total")]
        public decimal COTotal { get; set; }

        [Display(Name = "Cost")]
        public decimal Cost { get; set; }

        [Display(Name = "NET Sale")]
        public decimal NETSale { get; set; }

        [Display(Name = "Gross Profit")]
        public decimal GrossProfit { get; set; }


        [Required]
        [DataType(DataType.DateTime)]
        [Display(Name = "Contract Date")]
        public DateTime StartDate { get; set; }

        [DataType(DataType.DateTime)]
        [Display(Name = "Close Date")]
        public DateTime? CloseDate { get; set; }


        public int CompanyId { get; set; }

        [Required]
        [Display(Name = "Company Owner Amount")]
        public decimal CompanyOwnerAmount { get; set; }

        public decimal CompanyOwnerPercent { get; set; }


        public int EmployeeId { get; set; }

        public decimal EmpCommAmount { get; set; }
        public decimal EmpCommPercent { get; set; }
        public decimal EmpBalanceAmount { get; set; }


        public Employee? Employee { get; set; }
        public Company? Company { get; set; }


        public List<ChangeOrder> ChangeOrders { get; set; }
    }
}