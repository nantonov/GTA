﻿using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using AirlineTickets.Core.Entities;

namespace AirlineTickets.Data.EntityConfigurations
{
    public class AirlineTicketConfiguration : IEntityTypeConfiguration<AirlineTicket>
    {
        public void Configure(EntityTypeBuilder<AirlineTicket> builder)
        {
            builder.HasKey(t => t.Id);
            builder.Property(t => t.PassengerCredentials).HasMaxLength(200).IsRequired();
            builder.Property(t => t.DeparturePlace).HasMaxLength(200).IsRequired();
            builder.Property(t => t.ArrivalPlace).HasMaxLength(200).IsRequired();
            builder.Property(t => t.DepartureTime).IsRequired();
            builder.Property(t => t.ArrivalTime).IsRequired();
            builder.Property(t => t.Price).IsRequired();    
        }
    }
}
