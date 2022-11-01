using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TimeToWork.Data;
using TimeToWork.Models;
using ServiceProvider = TimeToWork.Models.ServiceProvider;

namespace TimeToWork.Pages.ServiceProviders
{
    public class DetailsModel : PageModel
    {
        private readonly TimeToWork.Data.TimeToWorkContext _context;

        public DetailsModel(TimeToWork.Data.TimeToWorkContext context)
        {
            _context = context;
        }

      public ServiceProvider ServiceProvider { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.ServiceProviders == null)
            {
                return NotFound();
            }

            var serviceprovider = await _context.ServiceProviders.FirstOrDefaultAsync(m => m.ID == id);
            if (serviceprovider == null)
            {
                return NotFound();
            }
            else 
            {
                ServiceProvider = serviceprovider;
            }
            return Page();
        }
    }
}
