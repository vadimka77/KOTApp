using KOTApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace KOTApp.Pages.org.emp
{
    public class EditModel : PageModel
    {
        private readonly Data.ApplicationDbContext _db;

        public Company Org;

        public EditModel(Data.ApplicationDbContext context)
        {
            _db = context;
        }

        [BindProperty]
        public Employee Employee { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int cid, int? eid)
        {
            Org = _db.Companies.Where(c => c.CompanyId == cid).FirstOrDefault();

            if (eid == null)
            {
                Employee = new Employee()
                {
                    CompanyId = cid,
                    HiredDate = DateTime.Now
                };
                return Page();
            }

            Employee =  await _db.Employees.FirstOrDefaultAsync(m => m.EmployeeId == eid);

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
                return Page();

            if (Employee.EmployeeId == 0)
                await _db.AddAsync(Employee);
            else
                _db.Attach(Employee).State = EntityState.Modified;
            
            await _db.SaveChangesAsync();

            return Redirect($"./Index?cid={Employee.CompanyId}");
        }
    }
}
