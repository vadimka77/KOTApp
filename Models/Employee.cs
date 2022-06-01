using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KOTApp.Models
{
    public class Employee
    {
        [Key] 
        public int EmployeeID { get; set; } 

        public int CompanyId { get; set; }

        [Required]
        [Display(Name ="Hired Date")]
        public DateTime HiredDate { get; set; }

        [Display(Name = "Term Date")]
        public DateTime? TermDate { get; set; }

        [Required]
        [Column(TypeName = "money")]
        [Display(Name ="Draw Amount")]
        public decimal DrawAmount { get; set; }

        public ICollection<TxEntry> txEntries { get; set; }

        public Company Company { get; set; }
    }
}
