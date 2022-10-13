using AirlineTickets.API.ViewModels.AirlineTicketCity;
using AirlineTickets.API.ViewModels.Hotel;

namespace AirlineTickets.API.ViewModels.City
{
    public class CityViewModel
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int Population { get; set; }
        public int Area { get; set; }

        public ICollection<TicketCityViewModel>? AirlineTicketCities { get; set; }
        public ICollection<HotelViewModel>? Hotels { get; set; }
    }
}
