using AirlineTicketsNotifications.DAL.Context;
using AirlineTicketsNotifications.DAL.Interfaces;
using AirlineTicketsNotifications.DAL.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AirlineTicketsNotifications.DAL.DI
{
    public static class DataAccessDI
    {
        public static void AddDataAccessDependencies(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("SqlServer");
            services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(connectionString));

            services.AddTransient<INotificationRepository, NotificationRepository>();
        }
    }
}
