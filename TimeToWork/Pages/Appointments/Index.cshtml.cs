using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using TimeToWork.Data;
using TimeToWork.Models;
using Microsoft.Extensions.Configuration;
using ContosoUniversity;

namespace TimeToWork.Pages.Appointments
{
    public class IndexModel : PageModel
    {
        private readonly TimeToWork.Data.TimeToWorkContext _context;

        public IndexModel(TimeToWork.Data.TimeToWorkContext context)
        {
            _context = context;
        }

        public IList<Appointment> Appointment { get;set; } = default!;

        //public string NameSort { get; set; }
        //public string DateSort { get; set; }
        //public string CurrentFilter { get; set; }
        //public string CurrentSort { get; set; }

        public async Task OnGetAsync(int? pageIndex)
        {
            if (_context.Appointments != null)
            {
                Appointment = await _context.Appointments
                .Include(a => a.Client)
                .Include(a => a.Service).ToListAsync();
            }

            //NameSort = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            //DateSort = sortOrder == "Date" ? "date_desc" : "Date";

            //CurrentFilter = searchString;

            //IQueryable<Appointment> studentsIQ = from s in _context.Appointments
            //                                 select s;
            //if (!String.IsNullOrEmpty(searchString))
            //{
            //    studentsIQ = studentsIQ.Where(s => s.Client.FullName.Contains(searchString) );
            //}

            //switch (sortOrder)
            //{
            //    case "name_desc":
            //        studentsIQ = studentsIQ.OrderByDescending(s => s.Client.FullName);
            //        break;
            //    case "Date":
            //        studentsIQ = studentsIQ.OrderBy(s => s.Date);
            //        break;
            //    case "date_desc":
            //        studentsIQ = studentsIQ.OrderByDescending(s => s.Date);
            //        break;
            //    default:
            //        studentsIQ = studentsIQ.OrderBy(s => s.Client.FullName);
            //        break;
            //}

            //Appointment = await studentsIQ.AsNoTracking().ToListAsync();
        }
    }
}
