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
                StartDate = DateTime.Now,
                EmpCommPercent = 0,//this % is employee-specific; will be filled after employee selected
                AdvancePercent = 0,// employee-specific
                COTotal = 0,
                //set current % settings for company
                CompanyOwnerPercent = Org.CompanyOwnerPercent,
                CompletionCertificate = "-"
            };
            return Page();
        }

        public IActionResult OnPost()
        {
			//Contract object created and already filled with user input from Form

			if (!ModelState.IsValid )
                return Page();

			// just find for selected employee specific commission percent
			var emp = _db.Employees.Find(Contract.EmployeeId);
            
            Contract.EmpCommPercent = emp.EmpCommPercent;
                        
            Contract.CalculateAutoFields();

            var txAdvanceToEmpForNewContract = new TxEntry()
            {
                TxDate = Contract.StartDate,
                TxType = TxType.Advance,
                TxAmount = Contract.AdvanceAmount,
                Employee = emp,
                Descr = $"{Contract.AdvancePercent} Advance",
                Contract = Contract, //<-- this must be Object contract, NOT ContractId; ContractId=0 for all new; updated after Save is done.
                // the EF will give new real ContractId to this TxEntry object when saving it - automatically!
                CompanyId = Contract.CompanyId
            };

            _db.Contracts.Add(Contract);
            _db.TxEntries.Add(txAdvanceToEmpForNewContract);

            _db.SaveChanges();

            return Redirect($"Details?cid={Contract.CompanyId}&jid={Contract.ContractId}");
        }
    }
}