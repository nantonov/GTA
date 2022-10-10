using AirlineTickets.Data.Entities;
using AirlineTickets.Data.EntityConfigurations;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace AirlineTickets.Data.Context
{
    public class ApplicationDbContext : DbContext
    {
        private readonly IConfiguration? _configuration;
        public DbSet<AirlineTicketEntity>? AirlineTickets { get; set; }
        public DbSet<CityEntity>? Cities { get; set; }
        public DbSet<HotelEntity>? Hotels { get; set; }
        public DbSet<AirlineTicketCityEntity>? AirlineTicketCities { get; set; }

        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
            Database.Migrate();
        }

        public ApplicationDbContext(DbContextOptions options, IConfiguration configuration) : base(options)
        {
            _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));

            Database.Migrate();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connectionString = _configuration.GetConnectionString("SqlServer");

            if (!string.IsNullOrEmpty(connectionString))
            {
                optionsBuilder.UseSqlServer(connectionString);
            }
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
