using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TalentedKidsCommunity.Data;
using TalentedKidsCommunity.Models;

namespace TalentedKidsCommunity.Pages.Kids
{
    public class IndexModel : PageModel
    {
        private readonly TalentedKidsCommunity.Data.CenterContext _context;

        public IndexModel(TalentedKidsCommunity.Data.CenterContext context)
        {
            _context = context;
        }

        // sorting and filtering properties
        public string NameSort { get; set; }
        public string DateSort { get; set; }
        public string AgeSort { get; set; }
        public string CurrentFilter { get; set; }
        public string CurrentSort { get; set; }


        public IList<Kid> Kids { get; set; } = default!;

        public async Task OnGetAsync(string sortOrder, string searchString)
        {


            // sorting functionality by last name, age , and enrollment date
            NameSort = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            DateSort = sortOrder == "date-asc" ? "date_desc" : "date-asc";
            AgeSort = sortOrder == "age-asc" ? "age_desc" : "age-asc";

            CurrentFilter = searchString;

            IQueryable<Kid> kidsIQ = from k in _context.Kids
                                     select k;

            switch (sortOrder)
            {
                case "name_desc":
                    kidsIQ = kidsIQ.OrderByDescending(k => k.LastName);
                    break;
                case "date-asc":
                    kidsIQ = kidsIQ.OrderBy(k => k.EnrollmentDate);
                    break;
                case "date_desc":
                    kidsIQ = kidsIQ.OrderByDescending(k => k.EnrollmentDate);
                    break;
                case "age-asc":
                    kidsIQ = kidsIQ.OrderBy(k => k.Age);
                    break;
                case "age_desc":
                    kidsIQ = kidsIQ.OrderByDescending(k => k.Age);
                    break;
                default:
                    kidsIQ = kidsIQ.OrderBy(k => k.LastName);
                    break;
            }

            // searching by last or first names
            if (!string.IsNullOrEmpty(searchString))
            {
                kidsIQ = kidsIQ.Where(k => k.LastName.Contains(searchString) || k.FirstName.Contains(searchString));
            }


            Kids = await kidsIQ.AsNoTracking().ToListAsync();
        }
    }
}
