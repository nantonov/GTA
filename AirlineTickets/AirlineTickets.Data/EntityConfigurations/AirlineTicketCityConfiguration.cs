using AirlineTickets.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AirlineTickets.Data.EntityConfigurations
{
    public class AirlineTicketCityConfiguration : IEntityTypeConfiguration<AirlineTicketCityEntity>
    {
        public void Configure(EntityTypeBuilder<AirlineTicketCityEntity> builder)
        {
            builder.HasKey(tc => new { tc.AirlineTicketId, tc.CityId });
            builder.ToTable("AirlineTicketsCities");
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
