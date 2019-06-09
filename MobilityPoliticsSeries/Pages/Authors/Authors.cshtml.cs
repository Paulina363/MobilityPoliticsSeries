using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using MobilityPoliticsSeries.Models;

namespace MobilityPoliticsSeries.Pages.Authors
{
    public class AuthorsModel : PageModel
    {
        private readonly MobilityPoliticsSeries.Models.MobilityPoliticsSeriesContext _context;

        public AuthorsModel(MobilityPoliticsSeries.Models.MobilityPoliticsSeriesContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Author Author { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Author.Add(Author);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}