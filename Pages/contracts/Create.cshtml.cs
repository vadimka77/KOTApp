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
            EmpSelectList = new SelectList(_db.Employees.Where(e => e.CompanyId == cid), "EmployeeId", "FullName");
            Contract = new Contract()
            {
                CompanyId = Org.CompanyId,
                StartDate = Org.CurrentTFStart,
                EmpCommPercent = 0,
                COTotal = 0,
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

            //Contract object created and already filled with user input from Form
            // just find for selected employee specific commission percent
            Contract.EmpCommPercent = Employee.EmpCommPercent;
                        
            Contract.CalculateAutoFields();

            var Transaction = new TxEntry()
            {
                TxDate = Contract.StartDate,
                TxType = TxType.Advance,
                TxAmount = Contract.AdvanceAmount,
                Employee = Employee,
                Descr = $"{Contract.AdvancePercent} Advance",
                Contract = Contract, //<-- this must be Object contract, NOT ContractId; ContractId=0 for all new; updated after Save is done.
                // the EF will give new real ContractId to this TxEntry object when saving it - automatically!
                CompanyId = Org.CompanyId
            };

            _db.Contracts.Add(Contract);
            _db.TxEntries.Add(Transaction);

            _db.SaveChanges();

            return Redirect($"./Index?oid={Org.CompanyOwnerId}&cid={Org.CompanyId}");
        }
    }
}