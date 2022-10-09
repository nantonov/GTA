using AirlineTickets.Core.Enums;

namespace AirlineTickets.Data.Entities
{
    public class AirlineTicketsCities
    {
        public int AirlineTicketId { get; set; }
        public int CityId { get; set; }
        public AirlineTicketEntity? AirlineTicket { get; set; }
        public CityEntity? City { get; set; }
        public CityStayingStatus StayingStatus { get; set; }
    }
}
