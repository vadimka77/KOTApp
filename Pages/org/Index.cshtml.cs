﻿using System;
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
        private readonly ApplicationDbContext _context;

        public IndexModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Company> Companies { get; set; }
        public IList<Company> Company { get; set; } = default!;

        public void OnGet(int oid)
        {
            Companies = _context.Companies.Where(o => o.CompanyOwnerId == oid).ToList();
        }
    }
}