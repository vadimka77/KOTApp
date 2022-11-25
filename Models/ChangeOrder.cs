using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace KOTApp.Models
{
    public class ChangeOrder
    {
        [Key]
        public int ChangeId { get; set; }

        public int ContractId { get; set; }

        [Display(Name ="Change Cost")]
        [Precision(18, 2)]
        public decimal Cost { get; set; }

        [Display(Name ="Change Description")]
        public string Description { get; set; }

        [Display(Name = "Change Order Number")]
        public string ChangeOrderNumber { get; set; }

        public Contract? Contract { get; set; }
    }
}