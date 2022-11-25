using KOTApp.Data;
using KOTApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace KOTApp.Pages.org
{
    public class OrgDetailsModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        public Company Org { get; set; } = default!;

        public OrgDetailsModel(ApplicationDbContext context)
        {
            _db = context;
        }


        public async Task<IActionResult> OnGetAsync(int cid)
        {

            var company = await _db.Companies.FirstOrDefaultAsync(c => c.CompanyId == cid);

            if (company == null)
                return NotFound();

            else 
                Org = company;

            return Page();
        }
    }
}
