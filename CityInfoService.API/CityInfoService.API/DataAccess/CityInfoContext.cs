using CityInfoService.API.Models;
using Microsoft.EntityFrameworkCore;

namespace CityInfoService.API.DataAccess
{
    public class CityInfoContext : DbContext
    {
        public CityInfoContext(DbContextOptions<CityInfoContext> options) : base(options)
        {
            //Database.EnsureDeleted();
            //Database.EnsureCreated();
        }

        public DbSet<City> Cities { get; set; }

        public DbSet<PointOfInterest> PointsOfInterest { get; set; }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer("DefaultConnection");
        //    base.OnConfiguring(optionsBuilder);
        //}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<City>().HasData(
                new City()
                {
                    Id = 1,
                    Name = "Varna",
                    Description = "The one with the bluest sea."
                },
                new City()
                {
                    Id = 2,
                    Name = "New York City",
                    Description = "The one with that big park."
                },
                new City()
                {
                    Id = 3,
                    Name = "Paris",
                    Description = "The one with the bigest museum."
                });

            modelBuilder.Entity<PointOfInterest>().HasData(
                new PointOfInterest()
                {
                    Id = 1,
                    CityId = 1,
                    Name = "Chalcolithic necropolis of Varna",
                    Description = "Тhe oldest technologically processed gold in the world."
                },
                new PointOfInterest()
                {
                    Id = 2,
                    CityId = 1,
                    Name = "Dormition of the Mother of God Cathedral",
                    Description = "The largest church building in Varna and the third largest cathedral in Bulgaria."
                },
                new PointOfInterest()
                {
                    Id = 3,
                    CityId = 2,
                    Name = "Empire State Building",
                    Description = "A 102-story skyscraper located in Midtown Manhattan."
                },
                new PointOfInterest()
                {
                    Id = 4,
                    CityId = 2,
                    Name = "Central Park",
                    Description = "The most visited urban park in the United States."
                },
                new PointOfInterest()
                {
                    Id = 5,
                    CityId = 3,
                    Name = "The Louvre",
                    Description = "The world's largest museum."
                });

            base.OnModelCreating(modelBuilder);
        }
    }
}
