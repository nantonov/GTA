using AirlineTickets.Business.Interfaces;
using AirlineTickets.Business.Models;
using AirlineTickets.Business.Services;
using AirlineTickets.Data.Entities;
using Microsoft.Extensions.DependencyInjection;

namespace AirlineTickets.Business.DI
{
    public static class BusinessLogicDI
    {
        public static void AddBusinessLogicDependencies(this IServiceCollection services)
        {
            services.AddTransient<IGenericService<AirlineTicket>, GenericService<AirlineTicket, AirlineTicketEntity>>();
            services.AddTransient<IGenericService<AirlineTicketCity>, GenericService<AirlineTicketCity, AirlineTicketCityEntity>>();
            services.AddTransient<IGenericService<City>, GenericService<City, CityEntity>>();
            services.AddTransient<IGenericService<Hotel>, GenericService<Hotel, HotelEntity>>();
        }
    }
}
