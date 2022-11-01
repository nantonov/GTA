using AirlineTickets.DAL.Context;
using AirlineTickets.DAL.Entities;
using AirlineTickets.DAL.Interfaces;
using AirlineTickets.DAL.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AirlineTickets.DAL.DI
{
    public static class DataAccessDI
    {
        public static void AddDataAccessDependencies(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("SqlServer");
            services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(connectionString));

            services.AddTransient(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddTransient<IGenericRepository<CityEntity>, CityRepository>();
            services.AddTransient<IGenericRepository<HotelEntity>, HotelRepository>();
            services.AddTransient<IGenericRepository<AirlineTicketEntity>, AirlineTicketRepository>();
            services.AddTransient<IAirlineTicketCityRepository, AirlineTicketCityRepository>();
        }
    }
}
