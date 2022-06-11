using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using KOTApp.Data;
using KOTApp.Models;

namespace KOTApp.Pages.org
{
    public class OrgDetailsModel : PageModel
    {
        private readonly KOTApp.Data.ApplicationDbContext _db;
        public Company Org { get; set; } = default!;

        public OrgDetailsModel(KOTApp.Data.ApplicationDbContext context)
        {
            _db = context;
        }
           

        public async Task<IActionResult> OnGetAsync(int cid)
        {
            if (cid == null)
            {
                return NotFound();
            }

            var company = await _db.Companies.FirstOrDefaultAsync(m => m.CompanyId == cid);
            if (company == null)
            {
                return NotFound();
            }
            else 
            {
                Org = company;
            }
            return Page();
        }
    }
}
