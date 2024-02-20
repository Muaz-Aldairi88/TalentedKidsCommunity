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

        public IList<Kid> Kid { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Kid = await _context.Kids.ToListAsync();
        }
    }
}
