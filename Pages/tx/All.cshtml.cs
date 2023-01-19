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
    public class AllModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        public AllModel(ApplicationDbContext context)
        {
            _db = context;
        }

        public Company Org;

        public List<TxEntry> Txes { get;set; } = default!;

        public async Task OnGetAsync(int cid)
        {
            if (_db.TxEntries != null)
            {
                Org = await _db.Companies
                                .Include(c => c.Employees)
                                .Where(c => c.CompanyId == cid)
                                .FirstOrDefaultAsync();

                Txes = await _db.TxEntries
                    .Where(t => t.CompanyId == cid
                                                   && t.TxDate > Org.CurrentTFStart 
                                                   && t.TxDate < Org.CurrentTFEnd)
                                          .ToListAsync();
            }
        }
    }
}
