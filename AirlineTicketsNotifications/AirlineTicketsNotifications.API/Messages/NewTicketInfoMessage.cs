using AirlineTicketsNotifications.Core.Enums;

namespace Messages
{
    public class NewTicketInfoMessage
    {
        public CityStayingStatus StayingStatus { get; set; }
        public string CityName { get; set; }
    }
}
