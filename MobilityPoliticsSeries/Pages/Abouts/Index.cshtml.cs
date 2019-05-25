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
    public class IndexModel : PageModel
    {
        private readonly MobilityPoliticsSeries.Models.MobilityPoliticsSeriesContext _context;

        public IndexModel(MobilityPoliticsSeries.Models.MobilityPoliticsSeriesContext context)
        {
            _context = context;
        }

        public IList<About> About { get;set; }

        public async Task OnGetAsync()
        {
            About = await _context.About.ToListAsync();
        }
    }
}
