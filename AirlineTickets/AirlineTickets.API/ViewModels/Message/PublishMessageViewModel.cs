using AirlineTickets.Core.Enums;

namespace AirlineTickets.API.ViewModels.Message
{
    public class PublishMessageViewModel
    {
        public string? CityName { get; set; }
        public CityStayingStatus StayingStatus { get; set; }
    }
}
