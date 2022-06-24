using KOTApp.Data;
using KOTApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace KOTApp.Pages.org.emp
{
    public class IndexModel : PageModel
    {
        public readonly ApplicationDbContext _db;

        public Company Org;
        public IEnumerable<Employee> Employees { get; set; } = default!;

        public IndexModel(ApplicationDbContext context)
        {
            _db = context;
        }

        public void OnGet(int cid)
        {
            Org = _db.Companies
                     .Include(e => e.Employees)
                     .Where(c => c.CompanyId == cid)
                     .FirstOrDefault();

            Employees = Org.Employees;
        }

        public IActionResult OnPostDraw(int cid)
        {
            Org = _db.Companies
                     .Include(e => e.Employees)
                     .Where(c => c.CompanyId == cid)
                     .FirstOrDefault();

            Employees = Org.Employees
                           .Where(e => e.CompanyId == cid && e.TermDate == null)
                           .ToList();

            List<TxEntry> txList = _db.TxEntries
                                      .Where(t => t.TxType == TxType.Draw
                                               && t.TxDate > Org.CurrentTFStart
                                               && t.TxDate < Org.CurrentTFEnd)
                                      .ToList();

            foreach (var emp in Employees)
            {
                var empDraw = txList.Where(t => t.EmployeeId == emp.EmployeeId)
                                    .FirstOrDefault();

                if (empDraw == null && emp.DrawAmount > 0)
                {
                    var txEntry = new TxEntry
                    {
                        TxDate = Org.CurrentTFEnd.AddSeconds(-1),
                        TxAmount = emp.DrawAmount * -1,
                        TxType = TxType.Draw,
                        EmployeeId = emp.EmployeeId,
                        Descr = "Draw"
                    };
                    _db.TxEntries.Add(txEntry);
                }

                if (empDraw != null)
                {
                    if (emp.DrawAmount == 0)
                        _db.TxEntries.Remove(empDraw);

                    else
                        empDraw.TxAmount = emp.DrawAmount * -1;
                }

            }

            _db.SaveChanges();
            return Page();
        }
    }
}