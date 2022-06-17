using KOTApp.Data;
using KOTApp.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace KOTApp.Pages.org
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        public CompanyOwner Owner;

        public IndexModel(ApplicationDbContext context)
        {
            _db = context;
        }

        public IEnumerable<Company> Companies { get; set; }

        public void OnGet(int oid)
        {
            Owner = _db.CompanyOwners
                .Include(c => c.Companies)
                .Where(o => o.CompanyOwnerId == oid)
                .FirstOrDefault();

            if (Owner == null)
                Redirect("/index");

            Companies = Owner.Companies;
        }
    }
}