using AirlineTicketsHistory.DAL.Entities;
using AirlineTicketsHistory.DAL.Interfaces;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;

namespace AirlineTicketsHistory.DAL.Context
{
    public class MongoDbContext : IMongoDbContext
    {
        public IMongoCollection<UserTicketsHistoryEntity> UserTicketsCollection { get; set; }
        private const string _connectionString = "Mongo";
        private const string _mongoDbName = "Mongo:TicketsHistoryDbName";
        private const string _ticketsCollectionName = "Mongo:TicketsHistoryCollectionName";

        public MongoDbContext(IConfiguration configuration)
        {
            var mongoClient = new MongoClient(configuration.GetConnectionString(_connectionString));
            var database = mongoClient.GetDatabase(configuration[_mongoDbName]);

            if (database.GetCollection<UserTicketsHistoryEntity>(configuration[_ticketsCollectionName]) is null)
            {
                database.CreateCollection(configuration[_ticketsCollectionName]);
            }

            UserTicketsCollection = database.GetCollection<UserTicketsHistoryEntity>(configuration[_ticketsCollectionName]);
        }
    }
}
