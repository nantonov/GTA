using AirlineTickets.Data.Context;
using AirlineTickets.Data.Entities;
using AirlineTickets.Data.Interfaces;
using AirlineTickets.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AirlineTickets.Data.DI
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
            services.AddTransient<IGenericRepository<AirlineTicketCityEntity>, AirlineTicketCityRepository>();
        }
    }
}
