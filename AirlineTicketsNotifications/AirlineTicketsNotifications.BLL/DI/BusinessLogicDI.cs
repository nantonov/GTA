using AirlineTicketsNotifications.BLL.Interfaces;
using AirlineTicketsNotifications.BLL.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using AirlineTicketsNotifications.DAL.DI;
using AirlineTicketsNotifications.BLL.Mapper.Profiles;

namespace AirlineTicketsNotifications.BLL.DI
{
    public static class BusinessLogicDI
    {
        public static void AddBLLLogicDependencies(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDataAccessDependencies(configuration);

            services.AddTransient<INotificationService, NotificationService>();
            services.AddTransient<IEmailService, EmailService>();

            services.AddAutoMapper(typeof(EntityModel));
        }
    }
}
