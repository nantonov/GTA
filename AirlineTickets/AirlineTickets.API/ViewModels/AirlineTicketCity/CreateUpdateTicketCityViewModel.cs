using AirlineTickets.Core.Enums;

namespace AirlineTickets.API.ViewModels.AirlineTicketCity
{
    public class CreateUpdateTicketCityViewModel
    {
        public int AirlineTicketId { get; set; }
        public int CityId { get; set; }
        public CityStayingStatus StayingStatus { get; set; }
    }
}
