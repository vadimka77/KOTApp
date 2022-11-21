using KOTApp.Models;
using KOTApp.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace KOTApp.Pages.contracts;

public class DetailsModel : PageModel
{
    private readonly ApplicationDbContext _db;

    public Company Org;

    public DetailsModel(ApplicationDbContext context)
    {
        _db = context;
    }

    public Contract Contract { get; set; } = default!;

    public async Task<IActionResult> OnGetAsync(int cid, int jid)
    {
		Contract = await _db.Contracts
            .Include(c => c.Company)
            .Include(c=>c.Employee)
            .Include(c => c.ChangeOrders)
            .Include(c=> c.Txes)
            .FirstOrDefaultAsync(c => c.ContractId == jid);

        Org = Contract.Company;

		//Contract.Txes = await _db.TxEntries.Where(t => t.ContractId == jid).ToListAsync();

        return Page();
    }
}