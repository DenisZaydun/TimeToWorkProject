using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TimeToWork.Data;
using TimeToWork.Models;
using ServiceProvider = TimeToWork.Models.ServiceProvider;

namespace TimeToWork.Pages.ServiceProviders
{
    public class EditModel : PageModel
    {
        private readonly TimeToWork.Data.TimeToWorkContext _context;

        public EditModel(TimeToWork.Data.TimeToWorkContext context)
        {
            _context = context;
        }

        [BindProperty]
        public ServiceProvider ServiceProvider { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.ServiceProviders == null)
            {
                return NotFound();
            }

            var serviceprovider =  await _context.ServiceProviders.FirstOrDefaultAsync(m => m.ID == id);
            ServiceProvider = await _context.ServiceProviders
                .Include(i => i.Services)
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.ID == id);

            if (ServiceProvider == null)
            {
                return NotFound();
            }
            ServiceProvider = serviceprovider;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(ServiceProvider).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ServiceProviderExists(ServiceProvider.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        

        private bool ServiceProviderExists(int id)
        {
          return _context.ServiceProviders.Any(e => e.ID == id);
        }
    }
}
