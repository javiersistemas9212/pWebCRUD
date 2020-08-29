using Microsoft.EntityFrameworkCore;
using ResortTropicalBeach.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ResortTropicalBeach.Data
{
    public class resortDbContext: DbContext
    {
        public resortDbContext(DbContextOptions<resortDbContext> options) : base(options)
        {
        }
        public DbSet<habitacion> habitacions { get; set; }
    }
}
