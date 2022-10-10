using AirlineTickets.Data.Entities;
using AirlineTickets.Data.EntityConfigurations;
using Microsoft.EntityFrameworkCore;

namespace AirlineTickets.Data.Context
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<AirlineTicketEntity>? AirlineTickets { get; set; }
        public DbSet<CityEntity>? Cities { get; set; }
        public DbSet<HotelEntity>? Hotels { get; set; }
        public DbSet<AirlineTicketCityEntity>? AirlineTicketCities { get; set; }

        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
            if (Database.IsRelational()) Database.Migrate();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AirlineTicketConfiguration());
            modelBuilder.ApplyConfiguration(new AirlineTicketCityConfiguration());
            modelBuilder.ApplyConfiguration(new CityConfiguration());
            modelBuilder.ApplyConfiguration(new HotelConfiguration());
        }
    }
}
