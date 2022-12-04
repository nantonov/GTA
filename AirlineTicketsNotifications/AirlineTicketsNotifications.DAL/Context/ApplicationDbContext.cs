using AirlineTicketsNotifications.DAL.Entities;
using AirlineTicketsNotifications.DAL.EntityConfigurations;
using Microsoft.EntityFrameworkCore;

namespace AirlineTicketsNotifications.DAL.Context
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<NotificationRequestEntity> NotificationRequests { get; set; }

        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
            //Database.EnsureCreated();
            if (Database.IsRelational()) Database.Migrate();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new NotificationRequestConfiguration());
        }
    }
}
