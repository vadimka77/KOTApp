using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using KOTApp.Data;
using KOTApp.Models;

namespace KOTApp.Pages.changeOrders
{
    public class AddModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        public Company Org;

        public AddModel(ApplicationDbContext context)
        {
            _db = context;
        }

        public IActionResult OnGet(int cid)
        {
            Org = _db.Companies.Where(c => c.CompanyId == cid).FirstOrDefault();

            return Page();
        }

        [BindProperty]
        public ChangeOrder ChangeOrder { get; set; } = default!;
        
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid || _db.ChangeOrders == null || ChangeOrder == null)
                return Page();

            _db.ChangeOrders.Add(ChangeOrder);

            await _db.SaveChangesAsync();

            return Redirect($"./Index?cid={Org.CompanyId}");
        }
    }
}
