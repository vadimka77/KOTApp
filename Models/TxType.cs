using System.ComponentModel.DataAnnotations;

namespace KOTApp.Models
{
    public enum TxType 
    {
        Draw,

        Commission,

        Adjustment,

        Advance,

        [Display(Name = "Special Draw")]
        SpecialDraw,
    }
}
