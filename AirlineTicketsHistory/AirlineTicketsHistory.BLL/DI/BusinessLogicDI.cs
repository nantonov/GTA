using AirlineTicketsHistory.BLL.Interfaces;
using AirlineTicketsHistory.BLL.Mapper.Profiles;
using AirlineTicketsHistory.BLL.Services;
using AirlineTicketsHistory.DAL.DI;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AirlineTicketsHistory.BLL.DI
{
    public static class BusinessLogicDI
    {
        public static void AddBLLLogicDependencies(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDataAccessDependencies(configuration);

            services.AddTransient<IUserTicketsHistoryService, UserTicketsHistoryService>();

            services.AddAutoMapper(typeof(EntityModel));
        }
    }
}
