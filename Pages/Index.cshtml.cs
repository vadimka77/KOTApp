using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Cryptography;

namespace KOTApp.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
            //TODO: this ownerid should be saved after login into session
            //here just pressetting it to always have it (imitate login done)
            HttpContext.Session.SetInt32("oid", 1);
        }
    }
}