using AirlineTickets.API.ViewModels.AirlineTicket;
using AirlineTickets.API.ViewModels.City;
using AirlineTickets.Core.Enums;

namespace AirlineTickets.API.ViewModels.AirlineTicketCity
{
    public class TicketCityViewModel
    {
        public int AirlineTicketId { get; set; }
        public int CityId { get; set; }
        public CityStayingStatus StayingStatus { get; set; }

        public TicketViewModel? AirlineTicket { get; set; }
        public CityViewModel? City { get; set; }
    }
}
