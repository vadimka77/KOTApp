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

        public SelectList EmpSelectList;

        public IActionResult OnGet(int? cid, int? jid)
        {
            Org = _db.Companies.Where(c => c.CompanyId == cid).FirstOrDefault();
            List<Employee> EmpList = _db.Employees.Where(e => e.CompanyId == cid).ToList();
            EmpSelectList = new SelectList(EmpList, "EmployeeId", "LastName");

            if (jid == null)
            {
                Job = new Contract()
                {
                    CompanyId = Org.CompanyId,
                    EmployeeId = EmpList.First().EmployeeId,
                    StartDate = DateTime.Now,
                    ContractAmount = 0,
                    ContractName = "",
                };
            }
            else
            {
                Job = _db.Contracts.Where(j => j.ContractId == jid).FirstOrDefault();
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            if (Job.ContractId == 0)
            {
                _db.Add(Job);
            }

            else
            {
                _db.Attach(Job).State = EntityState.Modified;
            }

            _db.SaveChanges();

            return Redirect($"./Index?&cid={Job.CompanyId}");
        }
    }
}
