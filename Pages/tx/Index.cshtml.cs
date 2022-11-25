using KOTApp.Data;
using KOTApp.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace KOTApp.Pages.tx
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        public IndexModel(ApplicationDbContext context)
        {
            _db = context;
        }

        public IList<TxEntry> TrEntries { get; set; } = default!;

        public Company Org;

        public async Task OnGetAsync(int cid)
        {
            Org = await _db.Companies.Where(c => c.CompanyId == cid)
                                     .FirstOrDefaultAsync();
            TrEntries = await _db.TxEntries.Include(e => e.Employee)
                                           .Include(c => c.Contract)
                                           .Where(t => t.TxType != TxType.Adjustment)
                                           .OrderByDescending(d => d.TxDate)
                                           .ToListAsync();
        }
    }
}