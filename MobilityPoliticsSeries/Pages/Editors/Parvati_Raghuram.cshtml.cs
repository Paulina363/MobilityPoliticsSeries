using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using MobilityPoliticsSeries.Models;

namespace MobilityPoliticsSeries.Pages.Editors
{
    public class Parvati_RaghuramModel : PageModel
    {
        private readonly MobilityPoliticsSeries.Models.MobilityPoliticsSeriesContext _context;

        public Parvati_RaghuramModel(MobilityPoliticsSeries.Models.MobilityPoliticsSeriesContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Editor Editor { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Editor.Add(Editor);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}