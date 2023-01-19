using Newtonsoft.Json.Linq;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace KOTApp.Models
{
    public enum TxType 
    {
		[EnumMember(Value = "Draw")]
		Draw,

		[EnumMember(Value = "Commission")]
		Commission,

		[EnumMember(Value = "Adjustment")]
		Adjustment,

		[EnumMember(Value = "Advance")]
		Advance,

        [Display(Name = "Special Draw")]
		[EnumMember(Value = "Special Draw")]
		SpecialDraw,
    }
}
