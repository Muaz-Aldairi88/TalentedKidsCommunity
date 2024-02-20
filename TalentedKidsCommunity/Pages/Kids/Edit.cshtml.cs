using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TalentedKidsCommunity.Data;
using TalentedKidsCommunity.Models;

namespace TalentedKidsCommunity.Pages.Kids
{
    public class EditModel : PageModel
    {
        private readonly TalentedKidsCommunity.Data.CenterContext _context;

        public EditModel(TalentedKidsCommunity.Data.CenterContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Kid Kid { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var kid =  await _context.Kids.FindAsync(id);// FindAsync(id) is more efficient than FirstorDefaultAsync()
            if (kid == null)
            {
                return NotFound();
            }
            Kid = kid;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync(int id)
        {
            var kidToUpdate = await _context.Kids.FindAsync(id);

            if (kidToUpdate == null)
            {
                return NotFound();
            }

            if (await TryUpdateModelAsync<Kid>(
                kidToUpdate,
                "kid",
                k => k.FirstName, k => k.LastName, k => k.Age, k => k.EnrollmentDate))
            {
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }

            return Page();
        }

        private bool KidExists(int id)
        {
            return _context.Kids.Any(e => e.KidID == id);
        }
    }
}
