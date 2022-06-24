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
            Contract orgJob = _db.Contracts
                .Include(e => e.Employee)
                .Include(c => c.Company)
                .Where(c => c.ContractId == Job.ContractId)
                .FirstOrDefault();
                        
            Org = Job.Company;

            bool IsClosedDateJustAdded = (!orgJob.CloseDate.HasValue && Job.CloseDate.HasValue);
            bool IsClosedDateChanged = (orgJob.CloseDate.HasValue 
                                        && Job.CloseDate.HasValue
                                        && orgJob.CloseDate.Value.Date != Job.CloseDate.Value.Date);

            if (IsClosedDateJustAdded || IsClosedDateChanged)
            {
                //verify that date in current pay-period
                if (Job.CloseDate.Value < Org.CurrentTFStart || Job.CloseDate.Value > Org.CurrentTFEnd)
                    ModelState.AddModelError("Job.CloseDate", "Closed Date must be in current Pay Period");

            }

            if (!ModelState.IsValid)
                return Page();
                
            if (orgJob.COTotal != Job.COTotal || orgJob.Cost != Job.Cost)
            {
                orgJob.AdvanceAmount = Job.AdvanceAmount = Job.ContractAmount / 100 * Job.AdvancePercent;
                orgJob.NETSale = Job.NETSale = Job.ContractAmount + Job.COTotal;
                orgJob.GrossProfit = Job.GrossProfit = Job.NETSale - Job.Cost;
                orgJob.CompanyOwnerAmount = Job.CompanyOwnerAmount = Job.GrossProfit / 100 * Job.CompanyOwnerPercent;
                orgJob.EmpCommAmount = Job.EmpCommAmount = (Job.GrossProfit - Job.CompanyOwnerAmount) / 100 * Job.EmpCommPercent;
                orgJob.EmpBalanceAmount = Job.EmpBalanceAmount = Job.EmpCommAmount - Job.AdvanceAmount;
            }
            if (IsClosedDateJustAdded)
            {
                //USER JUST CLOSED CONTRACT --> create TxEntry for commission
                orgJob.CloseDate = Job.CloseDate;
                var Transaction = new TxEntry()
                {
                    TxDate = orgJob.CloseDate.Value,
                    TxType = TxType.Commission,
                    TxAmount = orgJob.EmpBalanceAmount,
                    EmployeeId = orgJob.EmployeeId,
                    Descr = $"{orgJob.ContractName} Commission",
                    ContractId = orgJob.ContractId,
                    CompanyId = orgJob.CompanyId
                };
                _db.TxEntries.Add(Transaction);
            }
            if (IsClosedDateChanged)
            { 
                var Txentry = _db.TxEntries
                    .Where(t => t.ContractId == orgJob.ContractId && t.TxType == TxType.Commission)
                    .FirstOrDefault();
                Txentry.TxAmount = orgJob.EmpBalanceAmount;
                Txentry.TxDate = orgJob.CloseDate.Value;
                
            }
            //else //already CLOSED CONTRACT
            //
                //Validation: NEW closed date and original date must be in current time-period
                // certificate can be updated anytime
                // if new closed date provided, then find TxTentry for original commision
                // and update tx date
                // if orginal did not have clsoed date, we need to create TxEntry for commision
                
                
                if (IsClosedDateChanged)
                {
                    //then find TxEntry for original commision and change date
                }
            //}//

            _db.SaveChanges();
            return Redirect($"./Details?&cid={Job.CompanyId}&jid={Job.ContractId}");
        }
    }
}
