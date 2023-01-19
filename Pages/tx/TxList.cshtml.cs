using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using KOTApp.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace KOTApp.Pages.tx
{
    public class TxListModel : PageModel
    {
        private readonly KOTApp.Data.ApplicationDbContext _db;

        public TxListModel(KOTApp.Data.ApplicationDbContext context)
        {
            _db = context;
        }

        public Company Org;

        public List<TxEntry> TxList { get; set; } = default!;

        public SelectList EmpSelectList;
		public async Task OnGetAsync(int cid)
        {
			Org = await _db.Companies.Where(c => c.CompanyId == cid).FirstOrDefaultAsync();
			EmpSelectList = new SelectList(_db.Employees.Where(e => e.CompanyId == cid), "EmployeeId", "FullName");
			

		}
       
        
        public async Task<ContentResult> OnGetLoadListAsync(int cid)
        {
			/*
			  Org = await _db.Companies.Where(c => c.CompanyId == cid).FirstOrDefaultAsync();
                  && t.TxDate > Org.CurrentTFStart
                  && t.TxDate < Org.CurrentTFEnd)
            */
            //Thread.Sleep(6000);
			TxList = await _db.TxEntries
                .Include(t=>t.Employee)
                .Where(t => t.CompanyId == cid)
                .OrderBy(t => t.TxDate)
                .ToListAsync();
			
			//newton json + content restur
			string jsons = JsonConvert.SerializeObject(TxList,
				Formatting.None,
                new JsonSerializerSettings {
                    MaxDepth=1,
                    DateFormatString = "yyyy-MM-dd" });

            //return jsons;//pascal-case + dates
            return Content(jsons, "application/json", System.Text.Encoding.UTF8);

            //return new JsonResult(lst, 
            //    new System.Text.Json.JsonSerializerOptions
            //    { de
            //        DateFormatString="yyyy-MM-dd", 
            //        Formatting = Formatting.None, 
            // });//camel-case unless resolver-default
        }
    }
}
