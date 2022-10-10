using AirlineTickets.Core.Enums;

namespace AirlineTickets.Business.Models
{
    public class AirlineTicketCity
    {
        public int AirlineTicketId { get; set; }
        public int CityId { get; set; }
        public CityStayingStatus StayingStatus { get; set; }

        public AirlineTicket? AirlineTicket { get; set; }
        public City? City { get; set; }
    }
}
