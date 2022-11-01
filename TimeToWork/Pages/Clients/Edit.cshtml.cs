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

namespace TimeToWork.Pages.Clients
{
    public class EditModel : PageModel
    {
        private readonly TimeToWork.Data.TimeToWorkContext _context;

        public EditModel(TimeToWork.Data.TimeToWorkContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Client Client { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            //if (id == null || _context.Client == null)
            //{
            //    return NotFound();
            //}

            //var client =  await _context.Client.FirstOrDefaultAsync(m => m.ID == id);
            //if (client == null)
            //{
            //    return NotFound();
            //}
            //Client = client;
            //return Page();

            if (id == null)
            {
                return NotFound();
            }

            Client = await _context.Client.FindAsync(id);

            if (Client == null)
            {
                return NotFound();
            }
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync(int id)
        {
            //if (!ModelState.IsValid)
            //{
            //    return Page();
            //}

            //_context.Attach(Client).State = EntityState.Modified;

            //try
            //{
            //    await _context.SaveChangesAsync();
            //}
            //catch (DbUpdateConcurrencyException)
            //{
            //    if (!ClientExists(Client.ID))
            //    {
            //        return NotFound();
            //    }
            //    else
            //    {
            //        throw;
            //    }
            //}

            //return RedirectToPage("./Index");

            var clientToUpdate = await _context.Client.FindAsync(id);

            if (clientToUpdate == null)
            {
                return NotFound();
            }

            if (await TryUpdateModelAsync<Client>(
                clientToUpdate,
                "student",
                s => s.FirstMidName, s => s.LastName, s => s.PhoneNumber))
            {
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }

            return Page();
        }

        private bool ClientExists(int id)
        {
          return _context.Client.Any(e => e.ID == id);
        }
    }
}
