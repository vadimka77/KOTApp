using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using KOTApp.Data;
using KOTApp.Models;

namespace KOTApp.Pages.org
{
    public class CreateModel : PageModel
    {
        private readonly KOTApp.Data.ApplicationDbContext _context;

        public CreateModel(KOTApp.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        //public SelectList Owners { get; set; }
        public IActionResult OnGet()
        {
            //Owners = new SelectList(_context.CompanyOwners, "CompanyOwnerId", "OwnerName");
            return Page();
        }

        [BindProperty]
        public Company Company { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            //if (!ModelState.IsValid || _context.Companies == null || Company == null)
            //{
            //    return Page();
            //}

            await _context.Companies.AddAsync(Company);
            await _context.SaveChangesAsync();
            return RedirectToPage("./Index");
        }
    }
}
