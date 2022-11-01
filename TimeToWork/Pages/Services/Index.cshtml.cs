using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TimeToWork.Data;
using TimeToWork.Models;

namespace TimeToWork.Pages.Services
{
    public class IndexModel : PageModel
    {
        private readonly TimeToWork.Data.TimeToWorkContext _context;

        public IndexModel(TimeToWork.Data.TimeToWorkContext context)
        {
            _context = context;
        }

        public string NameSort { get; set; }
        public string CurrentFilter { get; set; }
        public string CurrentSort { get; set; }

        public IList<Service> Service { get;set; } = default!;

        public async Task OnGetAsync(string sortOrder, string searchString)
        {
            //if (_context.Services != null)
            //{
            //    Service = await _context.Services.ToListAsync();
            //}

            NameSort = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";

            CurrentFilter = searchString;

            IQueryable<Service> studentsIQ = from s in _context.Services
                                             select s;
            if (!String.IsNullOrEmpty(searchString))
            {
                studentsIQ = studentsIQ.Where(s => s.ServiceName.Contains(searchString)
                                       || s.ShortDescription.Contains(searchString));
            }

            switch (sortOrder)
            {
                case "name_desc":
                    studentsIQ = studentsIQ.OrderByDescending(s => s.ServiceName);
                    break;
                default:
                    studentsIQ = studentsIQ.OrderBy(s => s.ServiceName);
                    break;
            }

            Service = await studentsIQ.AsNoTracking().ToListAsync();
        }
    }
}
