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
    public class IndexModel : PageModel
    {
        private readonly TimeToWork.Data.TimeToWorkContext _context;

        public IndexModel(TimeToWork.Data.TimeToWorkContext context)
        {
            _context = context;
        }

        public IList<Client> Client { get;set; } = default!;

        public string NameSort { get; set; }
        public string CurrentFilter { get; set; }
        public string CurrentSort { get; set; }

        public async Task OnGetAsync(string sortOrder, string searchString)
        {
            //if (_context.Client != null)
            //{
            //    Client = await _context.Client.ToListAsync();
            //}

            NameSort = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            //DateSort = sortOrder == "Date" ? "date_desc" : "Date";

            CurrentFilter = searchString;

            IQueryable<Client> studentsIQ = from s in _context.Client
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
                default:
                    studentsIQ = studentsIQ.OrderBy(s => s.LastName);
                    break;
            }

            Client = await studentsIQ.AsNoTracking().ToListAsync();
        }
    }
}
