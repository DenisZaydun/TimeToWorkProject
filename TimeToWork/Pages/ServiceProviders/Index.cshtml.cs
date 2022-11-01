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
using ServiceProvider = TimeToWork.Models.ServiceProvider;

namespace TimeToWork.Pages.ServiceProviders
{
    public class IndexModel : PageModel
    {
        private readonly TimeToWork.Data.TimeToWorkContext _context;

        public IndexModel(TimeToWork.Data.TimeToWorkContext context)
        {
            _context = context;
        }

        public string NameSort { get; set; }
        public string DateSort { get; set; }
        public string CurrentFilter { get; set; }
        public string CurrentSort { get; set; }

        public IList<ServiceProvider> ServiceProvider { get;set; } = default!;

        public async Task OnGetAsync(string sortOrder, string searchString)
        {
            //if (_context.ServiceProviders != null)
            //{
            //    ServiceProvider = await _context.ServiceProviders.ToListAsync();
            //}

            NameSort = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            DateSort = sortOrder == "Date" ? "date_desc" : "Date";

            CurrentFilter = searchString;

            IQueryable<ServiceProvider> studentsIQ = from s in _context.ServiceProviders
                                                     select s;
            if (!String.IsNullOrEmpty(searchString))
            {
                studentsIQ = studentsIQ.Where(s => s.LastName.Contains(searchString)
                                       || s.FirstMidName.Contains(searchString));
            }

            switch (sortOrder)
            {
                case "name_desc":
                    studentsIQ = studentsIQ.OrderByDescending(s => s.LastName);
                    break;
                case "Date":
                studentsIQ = studentsIQ.OrderBy(s => s.HireDate);
                    break;
                case "date_desc":
                    studentsIQ = studentsIQ.OrderByDescending(s => s.HireDate);
                    break;
                default:
                    studentsIQ = studentsIQ.OrderBy(s => s.LastName);
                    break;
            }

            ServiceProvider = await studentsIQ.AsNoTracking().ToListAsync();
        }
    }
}
