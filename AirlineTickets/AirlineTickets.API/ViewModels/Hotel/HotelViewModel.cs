using AirlineTickets.API.ViewModels.City;

namespace AirlineTickets.API.ViewModels.Hotel
{
    public class HotelViewModel
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int StarsNumber { get; set; }
        public int RoomsNumber { get; set; }

        public int CityId { get; set; }
        public CityViewModel? City { get; set; }
    }
}
