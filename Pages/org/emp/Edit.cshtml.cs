using KOTApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace KOTApp.Pages.org.emp
{
    public class EditModel : PageModel
    {
        private readonly Data.ApplicationDbContext _context;

        public Company Org;

        public CompanyOwner OrgOwner;

        public EditModel(Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Employee Employee { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? eid, int cid)
        {
            Org = _context.Companies.Where(c => c.CompanyId == cid).FirstOrDefault();

            OrgOwner = _context.CompanyOwners.Where(c => c.CompanyOwnerId == cid).FirstOrDefault();

            var employee =  await _context.Employees.FirstOrDefaultAsync(m => m.EmployeeID == eid);

            Employee = employee;

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            _context.Attach(Employee).State = EntityState.Modified;
                
            await _context.SaveChangesAsync();

            return Redirect($"./Index?oid={Request.Query["oid"]}&cid={Request.Query["cid"]}");
        }
        public IActionResult OnPostFire(Employee emp)
        {
            Employee employee = _context.Employees.Find(emp.EmployeeID);
            employee.TermDate = DateTime.Now;
            _context.SaveChanges();
            return Redirect($"./Index?cid={Request.Query["cid"]}");
        }
    }
}
