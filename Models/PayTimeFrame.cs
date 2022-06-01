using System.ComponentModel.DataAnnotations;

namespace KOTApp.Models
{
    public class PayTimeFrame
    {
        [Key]
        public int PayTFId { get; set; } 
        public string TFDisplayName { get; set; }

        public DateTime TFStart { get; set; }
        public DateTime TFEnd { get; set; }
    }
}
