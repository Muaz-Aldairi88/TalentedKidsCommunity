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
    public class DetailsModel : PageModel
    {
        private readonly TalentedKidsCommunity.Data.CenterContext _context;

        public DetailsModel(TalentedKidsCommunity.Data.CenterContext context)
        {
            _context = context;
        }

        public Kid Kid { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var kid = await _context.Kids
                .Include(k => k.Enrollments)
                .ThenInclude(e => e.Course)
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.KidID == id);
            if (kid == null)
            {
                return NotFound();
            }
            else
            {
                Kid = kid;
            }
            return Page();
        }
    }
}
