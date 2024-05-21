using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProjFinRBEM.Models;
using ProjFinRBEM.Data;

namespace ProjFinRBEM.Data
{
    public class ProjFinRBEMContext : DbContext
    {
        public ProjFinRBEMContext (DbContextOptions<ProjFinRBEMContext> options)
            : base(options)
        {
        }

        public DbSet<ProjFinRBEM.Models.User> User { get; set; } = default!;

        public DbSet<ProjFinRBEM.Models.Profile> Profile { get; set; } = default!;
    }
}
