using AirlineTickets.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AirlineTickets.DAL.EntityConfigurations
{
    public class HotelConfiguration : IEntityTypeConfiguration<HotelEntity>
    {
        public void Configure(EntityTypeBuilder<HotelEntity> builder)
        {
            builder.HasKey(h => h.Id);
            builder.Property(h => h.Name).HasMaxLength(150).IsRequired();
            builder.Property(t => t.StarsNumber).IsRequired();
            builder.Property(t => t.RoomsNumber).IsRequired();
        }
    }
}
