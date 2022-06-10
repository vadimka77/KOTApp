using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KOTApp.Models
{
    public class Employee
    {
        [Key] 
        public int EmployeeID { get; set; } 

        public int CompanyId { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }

        [Required]
        [Display(Name ="Hired Date")]
        public DateTime HiredDate { get; set; }

        [Display(Name = "Term Date")]
        public DateTime? TermDate { get; set; }

        [Required]
        [Column(TypeName = "money")]
        [Display(Name ="Draw Amount")]
        public decimal DrawAmount { get; set; }

        [Required]
        [Display(Name = "Employee Commission %")]
        [Precision(10, 2)]
        public decimal EmpCommPercent { get; set; }

        public ICollection<TxEntry> txEntries { get; set; }

        public ICollection<Contract> contracts { get; set; }

        public Company Company { get; set; }
    }
}
