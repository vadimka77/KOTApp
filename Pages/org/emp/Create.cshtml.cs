using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using KOTApp.Data;
using KOTApp.Models;

namespace KOTApp.Pages.org.emp
{
    public class CreateModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public Company Org;

        public CreateModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public SelectList Companies { get; set; }

        public IActionResult OnGet(int cid, int oid)
        {
            Companies = new SelectList(_context.Companies, "CompanyId", "CompanyName");
            Org = _context.Companies.Where(c => c.CompanyId == cid).FirstOrDefault();
            return Page();
        }

        [BindProperty]
        public Employee Employee { get; set; } = default!;

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            await _context.Employees.AddAsync(Employee);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index", "", fragment: $"cid={Request.Query["cid"]}");
        }
    }
}
