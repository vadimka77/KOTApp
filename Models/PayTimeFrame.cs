using System.ComponentModel.DataAnnotations;

namespace KOTApp.Models
{
    public class PayTimeFrame
    {
        [Key]
        public int PayTFId { get; set; } 

        public string TFDisplayName { get; set; } = string.Empty;

        public PayFrequency TFPayFrequency { get; set; }//week/month
        public DateTime TFStart { get; set; }
        public DateTime TFEnd { get; set; }
    }
}
