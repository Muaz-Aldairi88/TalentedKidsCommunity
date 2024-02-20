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
    public class DeleteModel : PageModel
    {
        private readonly TalentedKidsCommunity.Data.CenterContext _context;
        private readonly ILogger<DeleteModel> _logger;
        public DeleteModel(TalentedKidsCommunity.Data.CenterContext context, ILogger<DeleteModel> logger)
        {
            _context = context;
            _logger = logger;
        }

        [BindProperty]
        public Kid Kid { get; set; } = default!;
        public string ErrorMessage { get; set; }
        public async Task<IActionResult> OnGetAsync(int? id, bool? saveChangesError = false)
        {
            if (id == null)
            {
                return NotFound();
            }

            var kid = await _context.Kids
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.KidID == id);

            if (kid == null)
            {
                return NotFound();
            }
            if (saveChangesError.GetValueOrDefault())
            {
                ErrorMessage = String.Format("Delete {ID} failed. Try again", id);
            }
            else
            {
                Kid = kid;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var kid = await _context.Kids.FindAsync(id);
            if (kid == null)
            {
                return NotFound();
            }

            try
            {
                _context.Kids.Remove(kid);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }
            catch (DbUpdateException ex)
            {
                _logger.LogError(ex, ErrorMessage);

                return RedirectToAction("./Delete",
                                     new { id, saveChangesError = true });
            }
        }
    }
}
