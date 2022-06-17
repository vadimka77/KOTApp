using System.ComponentModel.DataAnnotations;

namespace KOTApp.Models
{
    public enum TxType 
    {
        [Display(Name ="Draw")]
        Draw,

        [Display(Name = "Special Draw")]
        SpecialDraw,

        [Display(Name = "Commission")]
        Commission,

        [Display(Name = "Adjustment")]
        Adjustment
    }
}
