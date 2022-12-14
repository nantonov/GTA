namespace AirlineTicketsHistory.BLL.Tests.TestObjects.Models
{
    internal static class UserTicketHistoryModels
    {
        public static UserTicketsHistory HistoryModel = new()
        {
            UserId = "user"
        };

        public static List<UserTicketsHistory> HistoryModelsList = new()
        {
            new UserTicketsHistory()
            {
                UserId = "user1",
            },

            new UserTicketsHistory()
            {
                UserId = "user2",
            },

            new UserTicketsHistory()
            {
                UserId = "user3",
            },
        };
    }
}
