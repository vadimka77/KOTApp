using System.ComponentModel.DataAnnotations;

namespace KOTApp.Models
{
    public class ChangeOrder
    {
        [Key]
        public int ChangeId { get; set; }

        [Display(Name ="Change Cost")]
        public decimal Cost { get; set; }

        [Display(Name ="Change Description")]
        public string Description { get; set; }

        [Display(Name = "Change Order Number")]
        public string ChangeOrderNumber { get; set; }
    }
}