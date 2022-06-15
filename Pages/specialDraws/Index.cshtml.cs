using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using KOTApp.Data;
using KOTApp.Models;

namespace KOTApp.Pages.specialDraws
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        public IndexModel(ApplicationDbContext context)
        {
            _db = context;
        }

        public Company Org;
        public Employee Emp;

        public IList<TxEntry> SpecialDrawList { get;set; } = default!;

        public async Task OnGetAsync(int? cid)
        {
            Org = await _db.Companies
                           .Where(c => c.CompanyId == cid)
                           .FirstOrDefaultAsync();
            SpecialDrawList = await _db.TxEntries
                                       .Include(t => t.Employee)
                                       .Where(t => t.TxType == TxType.SpecialDraw 
                                                && t.CompanyId == cid
                                                && t.TxDate > Org.CurrentTFStart
                                                && t.TxDate < Org.CurrentTFEnd)
                                       .ToListAsync();
        }
    }
}
