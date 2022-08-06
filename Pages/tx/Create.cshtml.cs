using KOTApp.Data;
using KOTApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace KOTApp.Pages.tx
{
    public class CreateModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        public Company Org;

        public SelectList EmpSelectList, TxTypeSelectList;

        [BindProperty]
        public TxEntry TrEntry { get; set; } = default!;

        public CreateModel(ApplicationDbContext context)
        {
            _db = context;
        }

        public async Task<ActionResult> OnGet(int cid)
        {
            Org = await _db.Companies.Where(c => c.CompanyId == cid).FirstOrDefaultAsync();
            EmpSelectList = new SelectList(_db.Employees.Where(e => e.CompanyId == cid),
                                           "EmployeeId", "FullName");
            //TxTypeSelectList = new SelectList(_db.TxEntries, "TxType", "TxType"); // add distinct
            TxTypeSelectList = new SelectList(new List<string> { "Draw", "Adjustment", "Commission" });
            TrEntry = new TxEntry()
            {
                TxDate = DateTime.Now,
                TxAmount = 0,
                CompanyId = cid
            };
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid || _db.TxEntries == null || TrEntry == null)
                return Page();

            _db.TxEntries.Add(TrEntry);

            await _db.SaveChangesAsync();

            return Redirect($"./Index?cid={TrEntry.CompanyId}");
        }
    }
}
