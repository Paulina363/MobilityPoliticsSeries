﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MobilityPoliticsSeries.Models;

namespace MobilityPoliticsSeries.Pages.Abouts
{
    public class EditModel : PageModel
    {
        private readonly MobilityPoliticsSeries.Models.MobilityPoliticsSeriesContext _context;

        public EditModel(MobilityPoliticsSeries.Models.MobilityPoliticsSeriesContext context)
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

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(About).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AboutExists(About.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool AboutExists(int id)
        {
            return _context.About.Any(e => e.ID == id);
        }
    }
}
