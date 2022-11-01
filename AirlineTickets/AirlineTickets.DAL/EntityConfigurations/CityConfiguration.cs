using AirlineTickets.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AirlineTickets.DAL.EntityConfigurations
{
    public class CityConfiguration : IEntityTypeConfiguration<CityEntity>
    {
        public void Configure(EntityTypeBuilder<CityEntity> builder)
        {
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Name).HasMaxLength(150).IsRequired();
            builder.Property(t => t.Population).IsRequired();
            builder.Property(t => t.Area).IsRequired();

            builder.HasMany(c => c.Hotels)
                .WithOne(h => h.City);
        }
    }
}
