namespace AirlineTicketsNotifications.BLL.Tests.TestObjects.Entities
{
    internal static class NotificationRequestEntities
    {
        public static NotificationRequestEntity NotificationEntity = new()
        {
            Id = 1,
            Email = "test@gmail.com",
            CityName = "City",
            StayingStatus = CityStayingStatus.Arrival
        };
    }
}
