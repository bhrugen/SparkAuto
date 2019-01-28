using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SparkAuto.Utility;

namespace SparkAuto.Pages
{
    public class IndexModel : PageModel
    {
        public IActionResult OnGet()
        {
            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);

            if(claim==null)
            {
                return RedirectToPage("/Account/Login", new { area = "Identity" });
            }

            if(User.IsInRole(SD.AdminEndUser))
            {
                return RedirectToPage("/Users/Index");
            }
            return RedirectToPage("/Cars/Index");
        }
    }
}
