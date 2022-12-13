namespace AirlineTicketsHistory.BLL.Tests.TestObjects.Entities
{
    internal class UserTicketHistoryEntities
    {
        public static UserTicketsHistoryEntity HistoryEntity = new()
        {
            UserId = "user"
        };

        public static List<UserTicketsHistoryEntity> HistoryEntitiesList = new()
        {
            new UserTicketsHistoryEntity()
            {
                UserId = "user1",
            },

            new UserTicketsHistoryEntity()
            {
                UserId = "user2",
            },

            new UserTicketsHistoryEntity()
            {
                UserId = "user3",
            },
        };
    }
}
