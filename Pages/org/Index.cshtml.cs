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
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _db;
        public CompanyOwner Owner;

        public IndexModel(ApplicationDbContext context)
        {
            _db = context;
        }

        public IEnumerable<Company> Companies { get; set; }
     
        public void OnGet(int oid)
        {
            //single db trip to get owner and all companies 
            Owner = _db.CompanyOwners
                .Include(c => c.Companies)
                .Where(o => o.CompanyOwnerId == oid)
                .FirstOrDefault();
            
            if (Owner == null)
                Redirect("/index");
            Companies = Owner.Companies;//_context.Companies.Where(o => o.CompanyOwnerId == oid).ToList();
        }
    }
}