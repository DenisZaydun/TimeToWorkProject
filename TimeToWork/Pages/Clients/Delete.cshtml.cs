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
    public class DeleteModel : PageModel
    {
        private readonly TimeToWork.Data.TimeToWorkContext _context;
        private readonly ILogger<DeleteModel> _logger;

        public DeleteModel(TimeToWork.Data.TimeToWorkContext context,
                           ILogger<DeleteModel> logger)
        {
            _context = context;
            _logger = logger;
        }

        [BindProperty]
        public Client Client { get; set; }
        public string ErrorMessage { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id, bool? saveChangesError = false)
        {
            //if (id == null || _context.Client == null)
            //{
            //    return NotFound();
            //}

            //var client = await _context.Client.FirstOrDefaultAsync(m => m.ID == id);

            //if (client == null)
            //{
            //    return NotFound();
            //}
            //else 
            //{
            //    Client = client;
            //}
            //return Page();

            if (id == null)
            {
                return NotFound();
            }

            Client = await _context.Client
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.ID == id);

            if (Client == null)
            {
                return NotFound();
            }

            if (saveChangesError.GetValueOrDefault())
            {
                ErrorMessage = String.Format("Delete {ID} failed. Try again", id);
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            //if (id == null || _context.Client == null)
            //{
            //    return NotFound();
            //}
            //var client = await _context.Client.FindAsync(id);

            //if (client != null)
            //{
            //    Client = client;
            //    _context.Client.Remove(Client);
            //    await _context.SaveChangesAsync();
            //}

            //return RedirectToPage("./Index");

            if (id == null)
            {
                return NotFound();
            }

            var student = await _context.Client.FindAsync(id);

            if (student == null)
            {
                return NotFound();
            }

            try
            {
                _context.Client.Remove(student);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }
            catch (DbUpdateException ex)
            {
                _logger.LogError(ex, ErrorMessage);

                return RedirectToAction("./Delete",
                                     new { id, saveChangesError = true });
            }
        }
    }
}
