using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KOTApp.Models
{
    public enum TxType { Draw, SpecialDraw, Commission, Adjustment }

    public class TxEntry
    {
        [Key] 
        public int TxId { get; set; }

        public int EmployeeId { get; set; }
        public int CompanyId { get; set; }
        public int? ContractId { get; set; }

        public TxType TxType { get; set; }

        [Required]
        [Display(Name ="Tx Date")]
        public DateTime TxDate { get; set; }

        [Required]
        [Column(TypeName = "money")]
        [Display(Name ="Tx Amount")]
        public decimal TxAmount { get; set; }

        [Required]
        public string Descr { get; set; }

        public Employee? Employee { get; set; }

        public Contract? Contract { get; set; }

    }
}