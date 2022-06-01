using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KOTApp.Models
{
    public class Contract
    {
        [Key] 
        public int ContractId { get; set; }

        public int CompanyId { get; set; }
        public Company Company { get; set; }

        public string ContractName { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        [Display(Name ="Contract Date")] 
        public DateTime ContractDate { get; set; }

        [Required]
        [Column(TypeName = "money")]
        [Display(Name ="Contract Amount")]
        public decimal ContractAmount { get; set; }
    }
}