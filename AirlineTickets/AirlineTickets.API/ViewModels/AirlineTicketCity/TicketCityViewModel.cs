using AirlineTickets.Core.Enums;
using AirlineTickets.Data.Entities;

namespace AirlineTickets.API.ViewModels.AirlineTicketCity
{
    public class TicketCityViewModel
    {
        public int AirlineTicketId { get; set; }
        public int CityId { get; set; }
        public CityStayingStatus StayingStatus { get; set; }

        public AirlineTicketEntity? AirlineTicket { get; set; }
        public CityEntity? City { get; set; }
    }
}
