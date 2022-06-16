using KOTApp.Data;
using KOTApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace KOTApp.Pages.org
{
    public class EditModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        public EditModel(ApplicationDbContext context)
        {
            _db = context;
        }

        [BindProperty]
        public Company Company { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? oid, int? cid)
        {
            if (cid == null)
            {
                Company = new Company()
                {
                    CompanyOwnerId = oid.Value
                };
                return Page();
            }

            var company = await _db.Companies.FirstOrDefaultAsync(c => c.CompanyId == cid);

            if (company == null)
            {
                return NotFound();
            }
            Company = company;

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
                return Page();

            if (Company.CompanyId == 0)
                _db.Add(Company);

            else
                _db.Attach(Company).State = EntityState.Modified;

            await _db.SaveChangesAsync();
            
            return Redirect($"./OrgDetails?cid={Company.CompanyId}");
        }
    }
}
