using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KOTApp.Models
{
    public class Contract
    {
        [Key]
        public int ContractId { get; set; }

        [Display(Name = "Contract Name")] 
        public string ContractName { get; set; } = "";

        [Display(Name = "Completion Certificate")]
        public string? CompletionCertificate { get; set; }


        [Required]
        [Precision(18, 2)]
        [Display(Name = "Contract Amount")]
        public decimal ContractAmount { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = false, DataFormatString = "{0:C2}")]
        [Precision(10, 2)]
        public decimal AdvancePercent { get; set; }

        [Display(Name = "Advance Amount")]
        [DisplayFormat(ApplyFormatInEditMode = false, DataFormatString = "{0:C2}")]
        [Precision(18, 2)]
        public decimal AdvanceAmount { get; set; }

        [Display(Name = "Change Orders Total")]
        [Precision(18, 2)]
        public decimal COTotal { get; set; }

        [Display(Name = "Cost")]
        [Precision(18, 2)]
        public decimal Cost { get; set; }

        [Display(Name = "NET Sale")]
        [Precision(18, 2)]
        public decimal NETSale { get; set; }

        [Display(Name = "Gross Profit")]
        [Precision(18, 2)]
        public decimal GrossProfit { get; set; }


        [Required]
        [DataType(DataType.DateTime)]
        [Display(Name = "Contract Date")]
        [DisplayFormat(ApplyFormatInEditMode = false, DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime StartDate { get; set; }

        [DataType(DataType.DateTime)]
        [DisplayFormat(ApplyFormatInEditMode = false, DataFormatString = "{0:yyyy-MM-dd}")]
        [Display(Name = "Close Date")]
        public DateTime? CloseDate { get; set; }


        public int CompanyId { get; set; }

        [Required]
        [Display(Name = "Company Owner Amount")]
        [Precision(18, 2)]
        public decimal CompanyOwnerAmount { get; set; }

        [Precision(18, 2)]
        public decimal CompanyOwnerPercent { get; set; }


        public int EmployeeId { get; set; }

        [Precision(18, 2)]
        public decimal EmpCommAmount { get; set; }
        [Precision(18, 2)]
        public decimal EmpCommPercent { get; set; }
        [Precision(18, 2)]
        public decimal EmpBalanceAmount { get; set; }


        public Employee? Employee { get; set; }
        public Company? Company { get; set; }


        public List<ChangeOrder>? ChangeOrders { get; set; }

        public List<TxEntry>? Txes { get; set; }

        public void CalculateAutoFields()
        {
            AdvanceAmount = ContractAmount / 100 * AdvancePercent;
            NETSale = ContractAmount + COTotal;
            GrossProfit = NETSale - Cost;
            CompanyOwnerAmount = GrossProfit / 100 * CompanyOwnerPercent;
            EmpCommAmount = (GrossProfit - CompanyOwnerAmount) / 100 * EmpCommPercent;
            EmpBalanceAmount = EmpCommAmount - AdvanceAmount;
        }
    }
}