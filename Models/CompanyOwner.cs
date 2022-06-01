using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace KOTApp.Models
{
    public class CompanyOwner
    {
        [Key]
        public int CompanyOwnerId { get; set; }

        [Display(Name = "Owner Name")]
        public string OwnerName { get; set; }

        [Phone]
        [Display(Name ="Phone")]
        public string? OwnerPhone { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name ="Email Address")]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name ="Password")]
        public string Password { get; set; }

        ICollection<Company> Companies { get; set; }
    }
}
