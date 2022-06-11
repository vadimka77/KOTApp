﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using KOTApp.Data;
using KOTApp.Models;

namespace KOTApp.Pages.org
{
    public class EditModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        public EditModel(ApplicationDbContext context)
        {
            _db = context;
        }

        [BindProperty]
        public Company Company { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? oid, int? cid)
        {
            if (cid == null)
            {               
                Company = new Company()
                {
                    CompanyOwnerId = oid.Value
                };
                return Page();
            }
            // if cid is NOT NULL, find compnany
            var company =  await _db.Companies.FirstOrDefaultAsync(m => m.CompanyId == cid);
            if (company == null)
            {
                return NotFound();
            }
            Company = company;
           //ViewData["CompanyOwnerId"] = new SelectList(_context.CompanyOwners, "CompanyOwnerId", "Email");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            if (Company.CompanyId == 0)
            {
                _db.Add(Company);
            }
            else
            {
                _db.Attach(Company).State = EntityState.Modified;
            }

            await _db.SaveChangesAsync();
            //try
            //{
            //    await _context.SaveChangesAsync();
            //}
            //catch (DbUpdateConcurrencyException)
            //{
            //    if (!CompanyExists(Company.CompanyId))
            //    {
            //        return NotFound();
            //    }
            //    else
            //    {
            //        throw;
            //    }
            //}

            return Redirect($"./OrgDetails?oid={Company.CompanyOwnerId}");
        }

        //private bool CompanyExists(int id)
        //{
        //    return (_db.Companies?.Any(e => e.CompanyId == id)).GetValueOrDefault();
        //}
    }
}