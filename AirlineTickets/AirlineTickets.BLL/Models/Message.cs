using AirlineTickets.Core.Enums;

namespace AirlineTickets.BLL.Models
{
    public class Message
    {
        public string? CityName { get; set; }
        public CityStayingStatus StayingStatus { get; set; }
    }
}
