using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TimeToWork.Data;
using TimeToWork.Models;

namespace TimeToWork.Pages.Clients
{
    public class DetailsModel : PageModel
    {
        private readonly TimeToWork.Data.TimeToWorkContext _context;

        public DetailsModel(TimeToWork.Data.TimeToWorkContext context)
        {
            _context = context;
        }

      public Client Client { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            //var client = await _context.Client.FirstOrDefaultAsync(m => m.ID == id);

            Client = await _context.Client
                .Include(s => s.Appointments)
                .ThenInclude(e => e.Service)
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.ID == id);

            if (Client == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
