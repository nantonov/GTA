using AirlineTicketsHistory.DAL.Entities;
using AirlineTicketsHistory.DAL.Interfaces;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;

namespace AirlineTicketsHistory.DAL.Context
{
    public class MongoDbContext : IMongoDbContext
    {
        public IMongoCollection<UserTicketsHistoryEntity> UserTicketsCollection { get; set; }

        public MongoDbContext(IConfiguration configuration)
        {
            var mongoClient = new MongoClient(configuration.GetConnectionString("Mongo"));
            var database = mongoClient.GetDatabase(configuration["Mongo:TicketsHistoryDbName"]);

            if (database.GetCollection<UserTicketsHistoryEntity>(configuration["Mongo:TicketsHistoryCollectionName"]) is null)
            {
                database.CreateCollection("UserAirlineTickets");
            }

            UserTicketsCollection = database.GetCollection<UserTicketsHistoryEntity>(configuration["Mongo:TicketsHistoryCollectionName"]);
        }
    }
}
