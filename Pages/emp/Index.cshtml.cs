using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using KOTApp.Data;
using KOTApp.Models;

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

        public async Task OnGetAsync(int cid)
        {
            Org = await _db.Companies
                .Include(e=> e.Employees)
                .Where(c => c.CompanyId == cid).FirstOrDefaultAsync();

            Employees =  Org.Employees;
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
                .Where(t => t.TxType == TxType.Draw && t.TxDate > Org.CurrentTFStart && t.TxDate < Org.CurrentTFEnd)
                .ToList();

            foreach (var emp in Employees)
            {
                var empDraw = txList
                    .Where(t => t.EmployeeId == emp.EmployeeID)
                    .FirstOrDefault();

                //if no transaction found AND employee has draw > 0
                if (empDraw == null && emp.DrawAmount > 0)
                {
                    // add New Transaction for Employee
                    TxEntry txEntry = new TxEntry
                    {
                        TxDate = Org.CurrentTFEnd.AddSeconds(-1),
                        TxAmount = emp.DrawAmount * -1,
                        TxType = TxType.Draw,
                        EmployeeId = emp.EmployeeID,
                        Descr = "Draw"
                    };
                    _db.TxEntries.Add(txEntry);
                }
                //transaction entry found update amount or delete if 0
                if(empDraw != null )
                {
                    if (emp.DrawAmount == 0)
                        _db.TxEntries.Remove(empDraw);
                    else // todo: change Amount not saving
                        empDraw.TxAmount = emp.DrawAmount * -1;
                }
                
            }

            _db.SaveChanges();
            return Page();
            
        }
    }
} 