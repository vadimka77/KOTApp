using KOTApp.Data;
using KOTApp.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace KOTApp.Pages.org
{
    //verify migrations up-to-date
    // change money to decimal 16.2
    // update-database
    // change bread-crumbs remove mycompanies
    // rename create/index/delete to newContract empInfo etc.
    // org needs TFid for current Tf . WorkFrame is PaymentFrequncy
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
            //todo: after login, unique owner id saved to session
            //param oid need to get out of session
            Owner = _db.CompanyOwners
                .Include(c => c.Companies)
                .Where(o => o.CompanyOwnerId == oid)
                .FirstOrDefault();

            //save ownerid in session to avoid passing via query
            HttpContext.Session.SetInt32("oid", oid);

            if (Owner == null)
                Redirect("/index");

            Companies = Owner.Companies;
        }
    }
}