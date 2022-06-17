using KOTApp.Data;
using KOTApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace KOTApp.Pages.costChanges
{
    public class EditModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        public Company Org;
        public Contract Job;

        public EditModel(ApplicationDbContext context)
        {
            _db = context;
        }

        [BindProperty]
        public ChangeOrder CostChange { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int cid, int jid, int? chid)
        {
            Org = await _db.Companies
                           .Where(c => c.CompanyId == cid)
                           .Include(
                                    j => j.Contracts
                                    .Where(j => j.ContractId == jid)
                                    )
                           .FirstOrDefaultAsync();

            if (chid == null || _db.ChangeOrders == null)
                return NotFound();

            var costChange = await _db.ChangeOrders.FirstOrDefaultAsync(c => c.ChangeId == chid);

            if (costChange == null)
                return NotFound();

            CostChange = costChange;

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _db.Attach(CostChange).State = EntityState.Modified;

            try
            {
                await _db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CostChangeExists(CostChange.ChangeId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Redirect($"./Index?cid={Org.CompanyId}");
        }

        private bool CostChangeExists(int id)
        {
            return (_db.ChangeOrders?.Any(e => e.ChangeId == id)).GetValueOrDefault();
        }
    }
}
