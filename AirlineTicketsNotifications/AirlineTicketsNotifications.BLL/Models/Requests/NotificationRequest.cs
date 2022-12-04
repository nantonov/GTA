using AirlineTicketsNotifications.Core.Enums;

namespace AirlineTicketsNotifications.BLL.Models.Requests
{
    public class NotificationRequest
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public CityStayingStatus StayingStatus { get; set; }
        public string CityName { get; set; }
    }
}
