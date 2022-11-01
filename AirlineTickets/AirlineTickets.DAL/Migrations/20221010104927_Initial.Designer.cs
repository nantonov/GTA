﻿// <auto-generated />
using System;
using AirlineTickets.DAL.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace AirlineTickets.Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20221010104927_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("AirlineTickets.Data.Entities.AirlineTicketCityEntity", b =>
                {
                    b.Property<int>("AirlineTicketId")
                        .HasColumnType("int");

                    b.Property<int>("CityId")
                        .HasColumnType("int");

                    b.Property<int>("StayingStatus")
                        .HasColumnType("int");

                    b.HasKey("AirlineTicketId", "CityId");

                    b.HasIndex("CityId");

                    b.ToTable("AirlineTicketsCities", (string)null);
                });

            modelBuilder.Entity("AirlineTickets.Data.Entities.AirlineTicketEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("ArrivalTime")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DepartureTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("PassengerCredentials")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<int>("Price")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("AirlineTickets");
                });

            modelBuilder.Entity("AirlineTickets.Data.Entities.CityEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("Area")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<int>("Population")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Cities");
                });

            modelBuilder.Entity("AirlineTickets.Data.Entities.HotelEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int?>("CityId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<int>("RoomsNumber")
                        .HasColumnType("int");

                    b.Property<int>("StarsNumber")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CityId");

                    b.ToTable("Hotels");
                });

            modelBuilder.Entity("AirlineTickets.Data.Entities.AirlineTicketCityEntity", b =>
                {
                    b.HasOne("AirlineTickets.Data.Entities.AirlineTicketEntity", "AirlineTicket")
                        .WithMany("AirlineTicketCities")
                        .HasForeignKey("AirlineTicketId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AirlineTickets.Data.Entities.CityEntity", "City")
                        .WithMany("AirlineTicketCities")
                        .HasForeignKey("CityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AirlineTicket");

                    b.Navigation("City");
                });

            modelBuilder.Entity("AirlineTickets.Data.Entities.HotelEntity", b =>
                {
                    b.HasOne("AirlineTickets.Data.Entities.CityEntity", "City")
                        .WithMany("Hotels")
                        .HasForeignKey("CityId");

                    b.Navigation("City");
                });

            modelBuilder.Entity("AirlineTickets.Data.Entities.AirlineTicketEntity", b =>
                {
                    b.Navigation("AirlineTicketCities");
                });

            modelBuilder.Entity("AirlineTickets.Data.Entities.CityEntity", b =>
                {
                    b.Navigation("AirlineTicketCities");

                    b.Navigation("Hotels");
                });
#pragma warning restore 612, 618
        }
    }
}