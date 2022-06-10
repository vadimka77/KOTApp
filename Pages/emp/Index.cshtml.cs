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
        public readonly ApplicationDbContext _context;

        public Company Org;

        public CompanyOwner OrgOwner;

        public IndexModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Employee> Employees { get; set; } = default!;

        public async Task OnGetAsync(int cid)
        {
            if (_context.Employees != null)
            {
                Employees = await _context.Employees.Where(e => e.CompanyId == cid).ToListAsync();
                Org = _context.Companies.Where(c => c.CompanyId == cid).FirstOrDefault();
            }
        }

        public IActionResult OnPostDraw(int cid)
        {
            Org = _context.Companies.Where(c => c.CompanyId == cid).FirstOrDefault();
            Employees = _context.Employees.Where(e => e.CompanyId == cid && e.TermDate == null).ToList();
            List<TxEntry> txList = _context.TxEntries.Where(t => t.TxDate > Org.CurrentTFStart && t.TxDate < Org.CurrentTFEnd).ToList();

            foreach (var emp in Employees)
            {
                var empDraw = txList.Where(t => t.TxType == TxType.Draw && t.EmployeeId == emp.EmployeeID).FirstOrDefault();

                if (empDraw == null && emp.DrawAmount > 0)
                {
                    // add New Transaction for Employee
                    TxEntry txEntry = new TxEntry
                    {
                        TxType = TxType.Draw,
                        Employee = emp,
                        TxDate = DateTime.Now,
                        TxAmount = emp.DrawAmount * -1,
                        Descr = "Draw"
                    };
                    _context.TxEntries.Add(txEntry);
                }
                if(empDraw != null && emp.DrawAmount == 0)
                {
                    _context.TxEntries.Remove(empDraw);
                }
                // todo: change Amount not saving
                if(empDraw != null && emp.DrawAmount > 0)
                {
                    empDraw.TxAmount = emp.DrawAmount;
                }
            }

            _context.SaveChanges();
            return Page();
            
        }
    }
} 