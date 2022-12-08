using AirlineTicketsHistory.DAL.Context;
using AirlineTicketsHistory.DAL.Interfaces;
using AirlineTicketsHistory.DAL.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AirlineTicketsHistory.DAL.DI
{
    public static class DataAccessDI
    {
        public static void AddDataAccessDependencies(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("Mongo");
            services.AddSingleton<IMongoDbContext>(_ => new MongoDbContext(configuration));

            services.AddTransient<IUserTicketsHistoryRepository, UserTicketsHistoryRepository>();
        }
    }
}
