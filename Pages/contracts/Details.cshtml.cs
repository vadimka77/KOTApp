using KOTApp.Models;
using KOTApp.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace KOTApp.Pages.contracts
{
    public class DetailsModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        public Company Org;

        public Employee Emp;

        public DetailsModel(ApplicationDbContext context)
        {
            _db = context;
        }

        public Contract Contract { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int cid, int? jid)
        {
            Org = await _db.Companies.Include(e => e.Employees) 
                                     .Where(c => c.CompanyId == cid)
                                     .FirstOrDefaultAsync();

            if (jid == null || _db.Contracts == null)
                return NotFound();

            var contract = await _db.Contracts.Include(c => c.ChangeOrders).FirstOrDefaultAsync(c => c.ContractId == jid);

            Contract = contract;

            Contract.AdvanceAmount = Contract.ContractAmount * Contract.AdvancePercent;
            Contract.NETSale = Contract.ContractAmount + Contract.COTotal;
            Contract.GrossProfit = Contract.NETSale - Contract.Cost;
            Contract.CompanyOwnerAmount = Contract.GrossProfit * Contract.CompanyOwnerPercent;
            Contract.EmpCommAmount = (Contract.GrossProfit - Contract.CompanyOwnerAmount) * Contract.EmpCommPercent;
            Contract.EmpBalanceAmount = Contract.EmpCommAmount - Contract.AdvanceAmount; 
            return Page();
        }
    }
}
