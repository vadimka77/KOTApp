using KOTApp.Data;
using KOTApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace KOTApp.Pages.contracts
{
    public class CreateModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        [BindProperty]
        public Contract Contract { get; set; } = default!;

        public Company Org;

        public SelectList EmpSelectList;

        public CreateModel(ApplicationDbContext context)
        {
            _db = context;
        }

        public ActionResult OnGet(int cid)
        {
            Org = _db.Companies.Where(c => c.CompanyId == cid).FirstOrDefault();
            EmpSelectList = new SelectList(_db.Employees, "EmployeeId", "FullName");
            Contract = new Contract()
            {
                CompanyId = cid,
                StartDate = Org.CurrentTFStart,
                EmpCommPercent = 0,
                AdvancePercent = Org.EmployeeAdvancePercent,
                CompanyOwnerPercent = Org.CompanyOwnerPercent,
                CompletionCertificate = "-"
            };
            return Page();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid )
                return Page();

            var Employee = _db.Employees.Include(c => c.Company)
                                        .Where(c => c.EmployeeId == Contract.EmployeeId)
                                        .FirstOrDefault();

            Contract = new Contract();
            Contract.COTotal = 0;
            Contract.EmpCommPercent = Employee.EmpCommPercent;
            Contract.AdvanceAmount = Contract.ContractAmount / 100 * Contract.AdvancePercent;
            Contract.NETSale = Contract.ContractAmount + Contract.COTotal;
            Contract.GrossProfit = Contract.NETSale - Contract.Cost;
            Contract.CompanyOwnerAmount = Contract.GrossProfit / 100 * Contract.CompanyOwnerPercent;
            Contract.EmpCommAmount = (Contract.GrossProfit - Contract.CompanyOwnerAmount) / 100 * Contract.EmpCommPercent;
            Contract.EmpBalanceAmount = Contract.EmpCommAmount - Contract.AdvanceAmount;

            var Transaction = new TxEntry()
            {
                TxDate = Contract.StartDate,
                TxType = TxType.Advance,
                TxAmount = Contract.AdvanceAmount,
                Employee = Employee,
                Descr = $"{Contract.AdvancePercent} Advance",
                ContractId = Contract.ContractId,
                CompanyId = Contract.CompanyId
            };

            _db.Contracts.Add(Contract);
            _db.TxEntries.Add(Transaction);

            _db.SaveChanges();

            return Redirect($"./Index?oid={Employee.Company.CompanyOwnerId}&cid={Employee.CompanyId}");
        }
    }
}