using EasyParking.Domain.Entities;
using EasyParking.Domain.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace EasyParking.Domain
{
    public sealed class ParkingDbContext : IdentityDbContext<AppUser>
    {

        private readonly IConfigurationRoot _config;

        public ParkingDbContext(DbContextOptions<ParkingDbContext> options, 
                                IConfigurationRoot config)
            : base(options)
        {
            _config = config;
            Database.EnsureCreatedAsync().Wait();
        }


        public DbSet<Owner> Owners { get; set; }
        public DbSet<ParkingArea> Parkings { get; set; }
        public DbSet<ParkingSession> ParkingSessions { get; set; }
        public DbSet<Place> Places { get; set; }
        public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<Location> Locations { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer(_config["database:connection"]);
         
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Place>()
                .HasOne(p => p.Parking)
                .WithMany(p => p.Places)
                .HasForeignKey(p => p.ParkingId);
        }



    }
}
