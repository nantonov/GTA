using AirlineTicketsHistory.DAL.Entities;
using MongoDB.Driver;

namespace AirlineTicketsHistory.DAL.Interfaces
{
    public interface IMongoDbContext
    {
        public IMongoCollection<UserTicketsHistoryEntity> UserTicketsCollection { get; set; }
    }
}
