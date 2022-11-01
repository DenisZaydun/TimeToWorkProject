using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TimeToWork.Data;
using TimeToWork.Models;

namespace TimeToWork.Pages.Appointments
{
    public class DetailsModel : PageModel
    {
        private readonly TimeToWork.Data.TimeToWorkContext _context;

        public DetailsModel(TimeToWork.Data.TimeToWorkContext context)
        {
            _context = context;
        }

      public Appointment Appointment { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Appointments == null)
            {
                return NotFound();
            }

            var appointment = await _context.Appointments.Include(a => a.Client)
                .Include(a => a.Service).FirstOrDefaultAsync(m => m.AppointmentId == id);

            if (appointment == null)
            {
                return NotFound();
            }
            else 
            {
                Appointment = appointment;
            }
            return Page();
        }
    }
}
