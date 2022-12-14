using Microsoft.Extensions.Configuration;

namespace AirlineTicketsHistory.DAL.Tests
{
    public class DataTestsHelpers
    {
        protected MongoDbContext _context;

        public DataTestsHelpers()
        {
            Dictionary<string, string?>? myConfiguration = new()
            {
                {"ConnectionStrings:Mongo", "mongodb://localhost:27017"},
                {"Mongo:TicketsHistoryDbName", "TestAirlineTickets"},
                {"Mongo:TicketsHistoryCollectionName", "TestUserAirlineTickets"}
            };

            var config = new ConfigurationBuilder().AddInMemoryCollection(myConfiguration).Build();
            _context = new MongoDbContext(config);
        }
    }
}
