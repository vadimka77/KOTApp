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

        //public CompanyOwner OrgOwner;

        public EditModel(Data.ApplicationDbContext context)
        {
            _db = context;
        }

        [BindProperty]
        public Employee Employee { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? eid, int cid)
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
            // if eid is NOT NULL, load Employee from database
            Employee =  await _db.Employees.FirstOrDefaultAsync(m => m.EmployeeID == eid);

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
           
            if (!ModelState.IsValid)
            {
                return Page();

            }


            if (Employee.EmployeeID == 0)
                _db.Add(Employee);
            else
                _db.Attach(Employee).State = EntityState.Modified;
            
            await _db.SaveChangesAsync();

            return Redirect($"./Index?cid={Employee.CompanyId}");
        }
        public IActionResult OnPostFire(Employee emp)
        {
            Employee employee = _db.Employees.Find(emp.EmployeeID);
            employee.TermDate = DateTime.Now;
            _db.SaveChanges();

            return Redirect($"./Index?cid={employee.CompanyId}");
        }
    }
}
