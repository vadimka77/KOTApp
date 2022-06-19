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
    public class empModel : PageModel
    {
        private readonly KOTApp.Data.ApplicationDbContext _db;

        public empModel(KOTApp.Data.ApplicationDbContext context)
        {
            _db = context;
        }

        public Company Org;
        public Employee Emp;
        public IList<TxEntry> TxList { get;set; } = default!;

        public async Task OnGetAsync(int cid,int eid)
        {
            //emp has company, load both in 1 trip (becase txList may be empty)
            Emp = await _db.Employees
                        .Include(e => e.Company)
                          .Where(e => e.EmployeeId == eid)
                          .FirstOrDefaultAsync();

            Org = Emp.Company;

            TxList = await _db.TxEntries
                .Include(t => t.Contract)
                .Where(t => t.EmployeeId == Emp.EmployeeId
                    && t.TxDate > Org.CurrentTFStart && t.TxDate < Org.CurrentTFEnd)
                .OrderBy(t => t.TxDate)
                .AsNoTracking()
                .ToListAsync();
            
        }
    }
}
