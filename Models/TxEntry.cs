using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KOTApp.Models
{
    public class TxEntry
    {
        [Key] 
        public int TxId { get; set; }

        [Required]
        public string Descr { get; set; }

        [Required]
        [Precision(18, 2)]
        [Display(Name = "Tx Amount")]
        public decimal TxAmount { get; set; }

        public TxType TxType { get; set; }

        [Required]
        [Display(Name = "Tx Date")]
        public DateTime TxDate { get; set; }

        public int EmployeeId { get; set; }
        public int CompanyId { get; set; }
        public int? ContractId { get; set; }

        public Employee? Employee { get; set; }
        public Contract? Contract { get; set; }

    }
}