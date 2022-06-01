namespace KOTApp.Models
{
    public class EmployeePayRate
    {
        public int EmployeeId { get; set; }
        public Employee  Employee { get; set; } 


        public int PayTFId { get; set; }
        public PayTimeFrame PayTimeFrame { get; set; }

        public decimal TFCommPercent { get; set; }  

    }
}
