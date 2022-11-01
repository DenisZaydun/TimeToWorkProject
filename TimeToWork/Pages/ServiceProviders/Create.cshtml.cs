using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using TimeToWork.Data;
using TimeToWork.Models;
using ServiceProvider = TimeToWork.Models.ServiceProvider;

namespace TimeToWork.Pages.ServiceProviders
{
    public class CreateModel : PageModel
    {
        private readonly TimeToWork.Data.TimeToWorkContext _context;

        public CreateModel(TimeToWork.Data.TimeToWorkContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public ServiceProvider ServiceProvider { get; set; }
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.ServiceProviders.Add(ServiceProvider);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
