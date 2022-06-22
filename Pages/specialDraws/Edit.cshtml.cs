using KOTApp.Data;
using KOTApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace KOTApp.Pages.specialDraws
{
    public class EditModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        public EditModel(ApplicationDbContext context)
        {
            _db = context;
        }

        [BindProperty]
        public TxEntry TrEntry { get; set; } = default!;

        public Company Org;

        public SelectList EmpSelectList, TxTypeSelectList;

        public async Task<IActionResult> OnGetAsync(int? cid, int? tid)
        {
            Org = await _db.Companies.Where(c => c.CompanyId == cid).FirstOrDefaultAsync();
            List<Employee> EmpList = _db.Employees.Where(e => e.CompanyId == cid).ToList();
            EmpSelectList = new SelectList(EmpList, "EmployeeId", "FullName");
            //ViewData[""] = new SelectList(TxList, "TxType", "TxType");

            if (tid == null)
            {
                TrEntry = new TxEntry()
                {
                    CompanyId = Org.CompanyId,
                    TxType = TxType.SpecialDraw,
                    TxDate = DateTime.Now,
                    TxAmount = 0,
                    EmployeeId = EmpList.First().EmployeeId
                };
            }
            else
            {
                TrEntry = _db.TxEntries.Where(t => t.TxId == tid).FirstOrDefault();
            }

            return Page();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            if (TrEntry.TxId == 0)
            {
                _db.Add(TrEntry);
            }

            else
            {
                _db.Attach(TrEntry).State = EntityState.Modified;
            }

            _db.SaveChanges();

            return Redirect($"./Index?&cid={TrEntry.CompanyId}");
        }
    }
}