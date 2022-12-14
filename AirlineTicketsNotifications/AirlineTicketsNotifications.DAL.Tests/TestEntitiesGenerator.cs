namespace AirlineTicketsNotifications.DAL.Tests
{
    public static class TestEntitiesGenerator
    {
        private static Fixture _fixtureBuilder = new();

        public static NotificationRequestEntity GetNotificationRequestEntity() => 
            _fixtureBuilder.Build<NotificationRequestEntity>().Create();
    }
}
