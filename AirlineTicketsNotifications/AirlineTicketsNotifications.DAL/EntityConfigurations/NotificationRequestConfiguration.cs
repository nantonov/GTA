using AirlineTicketsNotifications.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AirlineTicketsNotifications.DAL.EntityConfigurations
{
    public class NotificationRequestConfiguration : IEntityTypeConfiguration<NotificationRequestEntity>
    {
        public void Configure(EntityTypeBuilder<NotificationRequestEntity> builder)
        {
            builder.HasKey(r => r.Id);
            builder.Property(r => r.Email).HasMaxLength(250).IsRequired();
            builder.Property(r => r.StayingStatus).IsRequired();
            builder.Property(r => r.CityName).HasMaxLength(150).IsRequired();
        }
    }
}
