using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TalentedKidsCommunity.Data;
using TalentedKidsCommunity.Models;

namespace TalentedKidsCommunity.Pages.Courses
{
    public class IndexModel : PageModel
    {
        private readonly TalentedKidsCommunity.Data.CenterContext _context;

        public IndexModel(TalentedKidsCommunity.Data.CenterContext context)
        {
            _context = context;
        }

        public IList<Course> Courses { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Courses = await _context.Courses
                .Include(c => c.Department)
                .AsNoTracking() // quicker to execute because Course entity retrived from the database don't need to be updated
                .ToListAsync();
        }
    }
}
