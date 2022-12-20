using AirlineTickets.Core.Enums;

namespace AirlineTickets.API.Messages
{
    public class NewTicketInfoMessage
    {
        public CityStayingStatus StayingStatus { get; set; }
        public string? CityName { get; set; }
    }
}
