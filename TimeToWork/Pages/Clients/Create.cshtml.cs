using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using TimeToWork.Data;
using TimeToWork.Models;

namespace TimeToWork.Pages.Clients
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
        public Client Client { get; set; }
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            //if (!ModelState.IsValid)
            //  {
            //      return Page();
            //  }

            //  _context.Client.Add(Client);
            //  await _context.SaveChangesAsync();

            //  return RedirectToPage("./Index");

            var emptyClient = new Client();

            if (await TryUpdateModelAsync<Client>(
                emptyClient,
                "client",   // Prefix for form value.
                s => s.FirstMidName, s => s.LastName, s => s.PhoneNumber))
            {
                _context.Client.Add(emptyClient);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }

            return Page();
        }
    }
}
