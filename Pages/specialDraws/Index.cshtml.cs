using KOTApp.Data;
using KOTApp.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

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

        public IList<TxEntry> TxList { get; set; } = default!;

        public async Task OnGetAsync(int? cid)
        {
            Org = await _db.Companies
                           .Where(c => c.CompanyId == cid)
                           .FirstOrDefaultAsync();

            TxList = await _db.TxEntries
                            .Include(t => t.Employee)
                            .Where(t => t.TxType == TxType.SpecialDraw
                                    || t.TxType == TxType.Adjustment
                                    && t.CompanyId == cid
                                    && t.TxDate > Org.CurrentTFStart
                                    && t.TxDate < Org.CurrentTFEnd)
                            .ToListAsync();
        }
    }
}
