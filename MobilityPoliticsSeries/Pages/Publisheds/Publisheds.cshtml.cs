using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using MobilityPoliticsSeries.Models;

namespace MobilityPoliticsSeries.Pages.Publisheds
{
    public class PublishedsModel : PageModel
    {
        private readonly MobilityPoliticsSeries.Models.MobilityPoliticsSeriesContext _context;

        public PublishedsModel(MobilityPoliticsSeries.Models.MobilityPoliticsSeriesContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Published Published { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Published.Add(Published);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}