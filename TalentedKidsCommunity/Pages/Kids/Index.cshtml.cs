using System;
using System.Collections.Generic;
using System.Configuration;
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

        private readonly IConfiguration _configuration;

        public IndexModel(TalentedKidsCommunity.Data.CenterContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }


        // sorting and filtering properties
        public string FirstNameSort { get; set; }
        public string LastNameSort { get; set; }
        public string DateSort { get; set; }
        public string AgeSort { get; set; }
        public string CurrentFilter { get; set; }
        public string CurrentSort { get; set; }

        // pagination functionallity
        public PaginatedList<Kid> Kids { get; set; }

        public async Task OnGetAsync(string sortOrder, string searchString, string currentFilter, int? pageIndex)
        {


            // sorting functionality by last name, age , and enrollment date
            LastNameSort = String.IsNullOrEmpty(sortOrder) ? "lastname_desc" : "";
            FirstNameSort = sortOrder == "firstname-asc" ? "firstname_desc" : "firstname-asc";
            DateSort = sortOrder == "date-asc" ? "date_desc" : "date-asc";
            AgeSort = sortOrder == "age-asc" ? "age_desc" : "age-asc";

            CurrentSort = sortOrder;

            //resets page index to 1 when there's a new search string.
            if (searchString != null)
            {
                pageIndex = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            CurrentFilter = searchString;

            IQueryable<Kid> kidsIQ = from k in _context.Kids
                                     select k;

            switch (sortOrder)
            {
                case "name_desc":
                    kidsIQ = kidsIQ.OrderByDescending(k => k.LastName);
                    break;
                case "firstname-asc":
                    kidsIQ = kidsIQ.OrderBy(k => k.FirstName);
                    break;
                case "firstname_desc":
                    kidsIQ = kidsIQ.OrderByDescending(k => k.FirstName);
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

            var pageSize = _configuration.GetValue("PageSize", 6);
            Kids = await PaginatedList<Kid>.CreateAsync(
                kidsIQ.AsNoTracking(), pageIndex ?? 1, pageSize);
        }
    }
}
