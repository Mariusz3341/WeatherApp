using Microsoft.EntityFrameworkCore;
using WeatherApp.Models;

namespace WeatherApp.Data
{
    public class CityWeatherDbContext : DbContext
    {
        public DbSet<CityWeather> Cities { get; set; } = null!;


        public CityWeatherDbContext(DbContextOptions<CityWeatherDbContext> options)
            : base(options) { }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CityWeather>().ToTable("Cities");
            modelBuilder.Entity<CityWeather>().HasData(
                    new CityWeather
                    {
                        Id = 1,
                        CityName = "Warsaw",
                        Country = "Poland",
                        Temp_C = 16.00m,
                        Temp_F = 60.80m,
                        Info = "Clear",
                        LastUpdate = DateTime.Now
                    },
                    new CityWeather
                    {
                        Id = 2,
                        CityName = "London",
                        Country = "United Kingdom",
                        Temp_C = 19.0m,
                        Temp_F = 66.20m,
                        Info = "Sunny",
                        LastUpdate = DateTime.Now
                    });
        }

    }
}
