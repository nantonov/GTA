namespace AirlineTicketsNotifications.BLL.Tests.TestObjects.Models
{
    internal static class NotificationRequestModels
    {
        public static NotificationRequest NotificationModel = new()
        {
            Id = 1,
            Email = "test@gmail.com",
            CityName = "City",
            StayingStatus = CityStayingStatus.Arrival
        };
    }
}
