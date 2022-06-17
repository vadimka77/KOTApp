using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KOTApp.Models
{
    public class EmployeePayRate
    {
        [Key]
        public int PayTFId { get; set; }

        [Precision(10, 2)]
        [DisplayFormat(ApplyFormatInEditMode = false, DataFormatString = "{0:C2}")]
        public decimal TFCommPercent { get; set; }

        public int EmployeeId { get; set; }

        public PayTimeFrame PayTimeFrame { get; set; }

        public Employee Employee { get; set; }

    }
}
