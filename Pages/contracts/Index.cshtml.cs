using KOTApp.Data;
using KOTApp.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace KOTApp.Pages.contracts
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        public IndexModel(ApplicationDbContext context)
        {
            _db = context;
        }

        public Company Org;

        public IList<Contract> ContractList { get; set; } = default!;

        public async Task OnGetAsync(int oid, int cid)
        {
            Org = await _db.Companies
                .Where(c => c.CompanyId == cid)
                .FirstOrDefaultAsync();

            ContractList = await _db.Contracts
                .Include(c => c.Employee)
                .Where(c => c.CompanyId == cid)
                .ToListAsync();
        }
    }
}