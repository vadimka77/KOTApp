using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using KOTApp.Data;
using KOTApp.Models;
using Microsoft.EntityFrameworkCore;

namespace KOTApp.Pages.tx
{
    public class CreateModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        public Company Org;

        public SelectList EmpSelectList, TxTypeSelectList;

        [BindProperty]
        public TxEntry TxEntry { get; set; } = default!;

        public CreateModel(ApplicationDbContext context)
        {
            _db = context;
        }

        public async Task<ActionResult> OnGet(int cid)
        {
            Org = await _db.Companies.Where(c => c.CompanyId == cid).FirstOrDefaultAsync();
            EmpSelectList = new SelectList(_db.Employees, "EmployeeId", "EmployeeId");
            TxTypeSelectList = new SelectList(_db.TxEntries, "TxType", "TxType");
            TxEntry = new TxEntry()
            {
                TxDate = DateTime.Now,
                TxAmount = 0,

            };
            return Page();
        }
        
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid || _db.TxEntries == null || TxEntry == null)
                return Page();

            _db.TxEntries.Add(TxEntry);

            await _db.SaveChangesAsync();

            return Redirect($"./Index?cid={TxEntry.CompanyId}");
        }
    }
}
