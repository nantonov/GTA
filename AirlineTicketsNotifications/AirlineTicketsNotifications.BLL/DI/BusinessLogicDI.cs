using AirlineTicketsNotifications.BLL.Interfaces;
using AirlineTicketsNotifications.BLL.Mapper.Profiles;
using AirlineTicketsNotifications.BLL.Services;
using AirlineTicketsNotifications.DAL.DI;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

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
