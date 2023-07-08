using Domain.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class RideShareDbContext : DbContext
    {

        public DbSet<Trip> Trip { get; set; }
        public DbSet<TripDetail> TripDetail { get; set; }
        public DbSet<Passanger> Passanger { get; set; }

        public RideShareDbContext(DbContextOptions<RideShareDbContext> options)
          : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseInMemoryDatabase("exampleDatabase");
        }
    }
}
