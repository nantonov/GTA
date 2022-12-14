using AirlineTicketsNotifications.Core.Enums;

namespace AirlineTicketsNotifications.API.Tests.TestEntities
{
    internal static class NotificationRequestEntities
    {
        public static NotificationRequestEntity RequestEntity = new()
        {
            Id = 1,
            CityName = "City",
            Email = "test@gmail.com",
            StayingStatus = CityStayingStatus.Arrival
        };

        public static List<NotificationRequestEntity> RequestEntitiesList = new()
        {
            new NotificationRequestEntity()
            {
                Id = 1,
                CityName = "City",
                Email = "test@gmail.com",
                StayingStatus = CityStayingStatus.Arrival
            },

            new NotificationRequestEntity()
            {
                Id = 2,
                CityName = "City2",
                Email = "test@gmail.com",
                StayingStatus = CityStayingStatus.Departure
            },

            new NotificationRequestEntity()
            {
                Id = 3,
                CityName = "City3",
                Email = "test@gmail.com",
                StayingStatus = CityStayingStatus.Transit
            }
        };
    }
}
