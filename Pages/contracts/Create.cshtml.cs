using KOTApp.Data;
using KOTApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace KOTApp.Pages.contracts
{
    public class CreateModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        public Company Org;

        public SelectList OrgSelectList;
        public SelectList EmpSelectList;

        public CreateModel(ApplicationDbContext context)
        {
            _db = context;
        }

        public IActionResult OnGet(int cid)
        {
            Org = _db.Companies.Where(c => c.CompanyId == cid).FirstOrDefault();
            OrgSelectList = new SelectList(_db.Companies, "CompanyId", "CompanyName");
            EmpSelectList = new SelectList(_db.Employees, "EmployeeId", "LastName");
            return Page();
        }

        [BindProperty]
        public Contract Contract { get; set; } = default!;

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid || _db.Contracts == null || Contract == null)
                return Page();

            _db.Contracts.Add(Contract);

            await _db.SaveChangesAsync();

            return RedirectToPage($"./Index?cid=");
        }
    }
}
