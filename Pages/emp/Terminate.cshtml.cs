using KOTApp.Data;
using KOTApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace KOTApp.Pages.emp
{
    public class TerminateModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        public TerminateModel(ApplicationDbContext context)
        {
            _db = context;
        }

        [BindProperty]
        public Employee Employee { get; set; } = default!;

        public Company Org;

        public async Task<IActionResult> OnGetAsync(int cid, int eid)
        {
            Org = await _db.Companies.Where(c => c.CompanyId == cid).FirstOrDefaultAsync();

            var employee = await _db.Employees.FirstOrDefaultAsync(m => m.EmployeeId == eid);

            Employee = employee;

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int eid)
        {
            var employee = await _db.Employees.FindAsync(eid);
            employee.TermDate = DateTime.Now;
            //Employee = employee;

           // _db.Employees.Remove(Employee);

            await _db.SaveChangesAsync();

            return Redirect($"./Index?cid={employee.CompanyId}");
        }
    }
}
