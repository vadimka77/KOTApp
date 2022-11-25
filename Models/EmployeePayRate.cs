using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KOTApp.Models
{
    public class EmployeePayRateHistory
    {
        [Key]
        public int ID { get; set; }
        public int EmployeeId { get; set; }
        public int PayTFId { get; set; }

        [Precision(10, 2)]
        [DisplayFormat(ApplyFormatInEditMode = false, DataFormatString = "{0:C2}")]
        public decimal TFCommPercent { get; set; }

        public PayTimeFrame? PayTF { get; set; }

        public Employee? Employee { get; set; }

    }
}
