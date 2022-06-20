using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using KOTApp.Data;
using KOTApp.Models;

namespace KOTApp.Pages.tx
{
    public class EmpModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        public EmpModel(ApplicationDbContext context)
        {
            _db = context;
        }

        public Company Org;
        public Employee Emp;
        public IList<TxEntry> TxList { get;set; } = default!;

        public async Task OnGetAsync(int eid)
        {
            Emp = await _db.Employees
                        .Include(e => e.Company)
                        .Where(e => e.EmployeeId == eid)
                        .FirstOrDefaultAsync();

            Org = Emp.Company;

            TxList = await _db.TxEntries
                               .Include(t => t.Contract)
                               .Where(t => t.EmployeeId == Emp.EmployeeId
                                   && t.TxDate > Org.CurrentTFStart 
                                   && t.TxDate < Org.CurrentTFEnd)
                               .OrderBy(t => t.TxDate)
                               .AsNoTracking()
                               .ToListAsync();
        }
    }
}
