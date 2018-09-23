using Microsoft.EntityFrameworkCore;
using TravelGuide.Core.Common.Entities;
using TravelGuide.Core.Configurations;

namespace TravelGuide.Core
{
    public class RepositoryContext : DbContext
    {
        public RepositoryContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Country> Countries { get; set; }

        public DbSet<City> Cities { get; set; }

        public DbSet<Route> Routes { get; set; }

        public DbSet<Location> Locations { get; set; }

        public DbSet<Coordinate> Coordinates { get; set; }

        public DbSet<RouteImage> RouteImages { get; set; }

        public DbSet<LocationImage> LocationImages { get; set; }

        public DbSet<User> Users { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CityConfiguration());
            modelBuilder.ApplyConfiguration(new CoordinateConfiguration());
            modelBuilder.ApplyConfiguration(new CountryConfiguration());
            modelBuilder.ApplyConfiguration(new LocationConfiguration());
            modelBuilder.ApplyConfiguration(new LocationImageConfiguration());
            modelBuilder.ApplyConfiguration(new RouteConfiguration());
            modelBuilder.ApplyConfiguration(new RouteImageConfiguration());
            modelBuilder.ApplyConfiguration(new UserConfiguration());

            base.OnModelCreating(modelBuilder);
        }
    }
}