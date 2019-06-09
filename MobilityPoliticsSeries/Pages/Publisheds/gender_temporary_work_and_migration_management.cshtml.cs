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
    public class gender_temporary_work_and_migration_managementModel : PageModel
    {
        private readonly MobilityPoliticsSeries.Models.MobilityPoliticsSeriesContext _context;

        public gender_temporary_work_and_migration_managementModel(MobilityPoliticsSeries.Models.MobilityPoliticsSeriesContext context)
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