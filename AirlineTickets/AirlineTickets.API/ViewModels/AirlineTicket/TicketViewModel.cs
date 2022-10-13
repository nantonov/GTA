using AirlineTickets.API.ViewModels.AirlineTicketCity;

namespace AirlineTickets.API.ViewModels.AirlineTicket
{
    public class TicketViewModel
    {
        public int Id { get; set; }
        public DateTime DepartureTime { get; set; }
        public DateTime ArrivalTime { get; set; }
        public int Price { get; set; }
        public string? PassengerCredentials { get; set; }

        public ICollection<TicketCityViewModel>? AirlineTicketCities { get; set; }
    }
}
