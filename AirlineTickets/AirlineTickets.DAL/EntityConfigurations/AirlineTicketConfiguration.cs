using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using AirlineTickets.DAL.Entities;

namespace AirlineTickets.DAL.EntityConfigurations
{
    public class AirlineTicketConfiguration : IEntityTypeConfiguration<AirlineTicketEntity>
    {
        public void Configure(EntityTypeBuilder<AirlineTicketEntity> builder)
        {
            builder.HasKey(t => t.Id);
            builder.Property(t => t.PassengerCredentials).HasMaxLength(200).IsRequired();
            builder.Property(t => t.DepartureTime).IsRequired();
            builder.Property(t => t.ArrivalTime).IsRequired();
            builder.Property(t => t.Price).IsRequired();
        }
    }
}
