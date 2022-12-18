using AirlineTicketsNotifications.Core.Enums;

namespace AirlineTicketsNotifications.API.Messages
{
    public class NewTicketInfoMessage
    {
        public CityStayingStatus StayingStatus { get; set; }
        public string CityName { get; set; }
    }
}
