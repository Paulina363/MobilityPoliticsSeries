using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MobilityPoliticsSeries.Models;

namespace MobilityPoliticsSeries.Pages.Abouts
{
    public class DeleteModel : PageModel
    {
        private readonly MobilityPoliticsSeries.Models.MobilityPoliticsSeriesContext _context;

        public DeleteModel(MobilityPoliticsSeries.Models.MobilityPoliticsSeriesContext context)
        {
            _context = context;
        }

        [BindProperty]
        public About About { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            About = await _context.About.FirstOrDefaultAsync(m => m.ID == id);

            if (About == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            About = await _context.About.FindAsync(id);

            if (About != null)
            {
                _context.About.Remove(About);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
