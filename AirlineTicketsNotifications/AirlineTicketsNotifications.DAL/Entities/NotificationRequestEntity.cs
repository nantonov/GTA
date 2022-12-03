using AirlineTicketsNotifications.Core.Enums;

namespace AirlineTicketsNotifications.DAL.Entities
{
    public class NotificationRequestEntity
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public CityStayingStatus StayingStatus { get; set; }
        public string CityName { get; set; }
    }
}
