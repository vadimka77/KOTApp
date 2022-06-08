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
        private readonly ApplicationDbContext _context;

        public Company Org;

        public CompanyOwner OrgOwner;

        public IndexModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Employee> Employee { get;set; } = default!;

        public async Task OnGetAsync(int oid, int cid)
        {
            if (_context.Employees != null)
            {
                Employee = await _context.Employees.Where(e => e.CompanyId == cid).ToListAsync();
                Org = _context.Companies.Where(c => c.CompanyId == cid).FirstOrDefault();
            }
        }
    }
}
