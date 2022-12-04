using AirlineTicketsNotifications.Core.Enums;

namespace AirlineTicketsNotifications.BLL.Models.TicketInfo
{
    public class NewTicketInfo
    {
        public CityStayingStatus StayingStatus { get; set; }
        public string CityName { get; set; }
    }
}
