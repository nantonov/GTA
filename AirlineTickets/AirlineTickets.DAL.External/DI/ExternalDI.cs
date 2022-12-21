using AirlineTickets.DAL.External.Interfaces;
using AirlineTickets.DAL.External.Services;
using Microsoft.Extensions.DependencyInjection;

namespace AirlineTickets.DAL.External.DI
{
    public static class ExternalDI
    {
        public static void AddExternalDependencies(this IServiceCollection services)
        {
            services.AddTransient<IExternalService, ExternalService>();
        }
    }
}
