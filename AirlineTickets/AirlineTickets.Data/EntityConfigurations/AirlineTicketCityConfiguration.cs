using AirlineTickets.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AirlineTickets.Data.EntityConfigurations
{
    public class AirlineTicketCityConfiguration : IEntityTypeConfiguration<AirlineTicketCity>
    {
        public void Configure(EntityTypeBuilder<AirlineTicketCity> builder)
        {
            builder.HasKey(tc => new { tc.AirlineTicketId, tc.CityId });
            builder.Property(t => t.StayingStatus).IsRequired();

            builder.HasOne(tc => tc.AirlineTicket)
                .WithMany(t => t.AirlineTicketCities)
                .HasForeignKey(tc => tc.AirlineTicketId);

            builder.HasOne(tc => tc.City)
                .WithMany(c => c.AirlineTicketCities)
                .HasForeignKey(tc => tc.CityId);
        }
    }
}
