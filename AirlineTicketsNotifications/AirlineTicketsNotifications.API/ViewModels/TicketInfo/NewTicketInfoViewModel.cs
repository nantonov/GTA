using AirlineTicketsNotifications.Core.Enums;

namespace AirlineTicketsNotifications.API.ViewModels.TicketInfo
{
    public class NewTicketInfoViewModel
    {
        public CityStayingStatus StayingStatus { get; set; }
        public string CityName { get; set; }
    }
}
