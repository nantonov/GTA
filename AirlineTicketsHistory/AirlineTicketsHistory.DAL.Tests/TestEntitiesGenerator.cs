namespace AirlineTicketsHistory.DAL.Tests
{
    public static class TestEntitiesGenerator
    {
        private static Fixture _fixtureBuilder = new();

        public static UserTicketsHistoryEntity GetUserTicketsHistoryEntity() => _fixtureBuilder.Build<UserTicketsHistoryEntity>()
            .Without(h => h.AirlineTickets).With(h => h.UserId, "user").Create();
    }
}
