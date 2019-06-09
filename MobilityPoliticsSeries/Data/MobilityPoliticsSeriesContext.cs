using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MobilityPoliticsSeries.Models;

namespace MobilityPoliticsSeries.Models
{
    public class MobilityPoliticsSeriesContext : DbContext
    {
        public MobilityPoliticsSeriesContext (DbContextOptions<MobilityPoliticsSeriesContext> options)
            : base(options)
        {
        }

        public DbSet<MobilityPoliticsSeries.Models.About> About { get; set; }

        public DbSet<MobilityPoliticsSeries.Models.Editor> Editor { get; set; }

        public DbSet<MobilityPoliticsSeries.Models.Author> Author { get; set; }

        public DbSet<MobilityPoliticsSeries.Models.Published> Published { get; set; }
    }
}
