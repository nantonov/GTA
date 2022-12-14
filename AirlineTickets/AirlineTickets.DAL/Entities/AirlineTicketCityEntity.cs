using AirlineTickets.Core.Enums;

namespace AirlineTickets.DAL.Entities
{
    public class AirlineTicketCityEntity
    {
        public int AirlineTicketId { get; set; }
        public int CityId { get; set; }
        public CityStayingStatus StayingStatus { get; set; }

        public AirlineTicketEntity? AirlineTicket { get; set; }
        public CityEntity? City { get; set; }
    }
}
