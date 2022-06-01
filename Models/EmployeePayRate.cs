using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KOTApp.Models
{
    public class EmployeePayRate
    {
        public int EmployeeId { get; set; }
        public Employee  Employee { get; set; }

        [Key]
        public int PayTFId { get; set; }
        public PayTimeFrame PayTimeFrame { get; set; }

        [Column(TypeName = "money")]
        public decimal TFCommPercent { get; set; }  

    }
}
