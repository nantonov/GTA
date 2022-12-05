using AirlineTickets.Core.Enums;

namespace AirlineTickets.API.ViewModels.TicketInfo
{
    public class NewTicketInfoViewModel
    {
        public CityStayingStatus StayingStatus { get; set; }
        public string? CityName { get; set; }
    }
}
