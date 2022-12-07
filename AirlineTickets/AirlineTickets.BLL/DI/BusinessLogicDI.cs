using AirlineTickets.BLL.Interfaces;
using AirlineTickets.BLL.Mapper.Profiles;
using AirlineTickets.BLL.Models;
using AirlineTickets.BLL.Services;
using AirlineTickets.DAL.DI;
using AirlineTickets.DAL.Entities;
using AutoMapper;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AirlineTickets.BLL.DI
{
    public static class BLLLogicDI
    {
        public static void AddBLLLogicDependencies(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDataAccessDependencies(configuration);

            services.AddTransient<IGenericService<AirlineTicket>, GenericService<AirlineTicket, AirlineTicketEntity>>();
            services.AddTransient<IAirlineTicketCityService, AirlineTicketCityService>();
            services.AddTransient<IGenericService<City>, GenericService<City, CityEntity>>();
            services.AddTransient<IGenericService<Hotel>, GenericService<Hotel, HotelEntity>>();
            services.AddTransient<IHttpClientService, HttpClientService>();

            services.AddAutoMapper(typeof(EntityModel));
        }
    }
}
