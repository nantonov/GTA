namespace AirlineTicketsHistory.API.Tests.TestEntities
{
    internal static class UserTicketHistoryEntities
    {
        public static UserTicketsHistoryEntity HistoryEntity = new()
        {
            UserId = "user"
        };

        public static UserTicketsHistoryEntity HistoryEntityWithTicket = new()
        {
            UserId = "user",
            AirlineTickets = new List<AirlineTicketEntity> { new AirlineTicketEntity() { TicketId = 1 } }
        };

        public static IEnumerable<UserTicketsHistoryEntity> HistoryEntitiesList = new List<UserTicketsHistoryEntity>()
        {
            new UserTicketsHistoryEntity()
            {
                UserId = "user1"
            },

            new UserTicketsHistoryEntity()
            {
                UserId = "user2"
            },

            new UserTicketsHistoryEntity()
            {
                UserId = "user3"
            }
        };
    }
}
