using MongoDB.Bson.Serialization.Attributes;

namespace AirlineTicketsHistory.DAL.Entities
{
    [BsonIgnoreExtraElements]
    public class UserTicketsHistoryEntity
    {
        public string? UserId { get; set; }
        public List<AirlineTicketEntity>? AirlineTickets { get; set; }
    }
}
