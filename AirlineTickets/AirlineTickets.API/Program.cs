using AirlineTickets.Business.Interfaces;
using AirlineTickets.Business.Models;
using AirlineTickets.Business.Services;
using AirlineTickets.Data.Context;
using AirlineTickets.Data.Entities;
using AirlineTickets.Data.Interfaces;
using AirlineTickets.Data.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var configurationBuilder = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
var connectionString = configurationBuilder.GetConnectionString("SqlServer");
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(connectionString))
    .AddTransient(typeof(IGenericRepository<>), typeof(GenericRepository<>))
    .AddTransient<IGenericRepository<CityEntity>, CityRepository>()
    .AddTransient<IGenericRepository<HotelEntity>, HotelRepository>()
    .AddTransient<IGenericRepository<AirlineTicketEntity>, AirlineTicketRepository>()
    .AddTransient<IGenericRepository<AirlineTicketCityEntity>, AirlineTicketCityRepository>()
    .AddTransient<IGenericService<AirlineTicket>, GenericService<AirlineTicket, AirlineTicketEntity>>()
    .AddTransient<IGenericService<AirlineTicketCity>, GenericService<AirlineTicketCity, AirlineTicketCityEntity>>()
    .AddTransient<IGenericService<City>, GenericService<City, CityEntity>>()
    .AddTransient<IGenericService<Hotel>, GenericService<Hotel, HotelEntity>>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
