using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using TalentedKidsCommunity.Data;
using TalentedKidsCommunity.Models;

namespace TalentedKidsCommunity.Pages.Kids
{
    public class CreateModel : PageModel
    {
        private readonly TalentedKidsCommunity.Data.CenterContext _context;

        public CreateModel(TalentedKidsCommunity.Data.CenterContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Kid Kid { get; set; } = default!;

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            var emptyKid = new Kid();

            // to prevent over-posting
            if (await TryUpdateModelAsync<Kid>(
                emptyKid,
                "kid",   // Prefix for form value.
                k => k.FirstName, k => k.LastName, k => k.Age, k => k.EnrollmentDate))
            {
                _context.Kids.Add(emptyKid);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }

            return Page();



        }
    }
}
