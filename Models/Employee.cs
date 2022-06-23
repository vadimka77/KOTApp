using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KOTApp.Models
{
    public class Employee
    {
        [Key] 
        public int EmployeeId { get; set; }


        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [NotMapped]
        public string FullName => $"{FirstName} {LastName}";

        [Required]
        [Display(Name ="Hired Date")]
        public DateTime HiredDate { get; set; }

        [Display(Name = "Term Date")]
        public DateTime? TermDate { get; set; }

        [Required]
        [Column(TypeName = "money")]
        [Display(Name ="Draw Amount")]
        [DisplayFormat(ApplyFormatInEditMode = false, DataFormatString = "{0:C2}")]
        public decimal DrawAmount { get; set; }

        [Required]
        [Display(Name = "Commission %")]
        [Precision(10, 2)]
        [DisplayFormat(ApplyFormatInEditMode = false, DataFormatString = "{0:C2}")]
        public decimal EmpCommPercent { get; set; }

        public ICollection<TxEntry>? TxEntries { get; set; }
        public ICollection<Contract>? Contracts { get; set; }


        public int CompanyId { get; set; }

        public Company? Company { get; set; }
    }
}