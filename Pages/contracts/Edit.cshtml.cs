using KOTApp.Data;
using KOTApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace KOTApp.Pages.contracts
{
    public class EditModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        public EditModel(ApplicationDbContext context)
        {
            _db = context;
        }

        [BindProperty]
        public Contract Job { get; set; } = default!;

        public Company Org;

        public IActionResult OnGet(int jid)
        {
            Job = _db.Contracts.Include(e => e.Employee)
                               .Include(c => c.Company)
                               .Where(j => j.ContractId == jid)
                               .FirstOrDefault();
            Org = Job.Company;

            return Page();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
                return Page();

            Job.AdvanceAmount = Job.ContractAmount / 100 * Job.AdvancePercent;
            Job.NETSale = Job.ContractAmount + Job.COTotal;
            Job.GrossProfit = Job.NETSale - Job.Cost;
            Job.CompanyOwnerAmount = Job.GrossProfit / 100 * Job.CompanyOwnerPercent;
            Job.EmpCommAmount = (Job.GrossProfit - Job.CompanyOwnerAmount) / 100 * Job.EmpCommPercent;
            Job.EmpBalanceAmount = Job.EmpCommAmount - Job.AdvanceAmount;

            _db.Attach(Job).State = EntityState.Modified;

            _db.SaveChanges();
            return Redirect($"./Details?&cid={Job.CompanyId}&jid={Job.ContractId}");
        }
    }
}
