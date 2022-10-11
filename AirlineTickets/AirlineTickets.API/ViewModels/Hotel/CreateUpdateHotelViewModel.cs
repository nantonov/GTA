namespace AirlineTickets.API.ViewModels.Hotel
{
    public class CreateUpdateHotelViewModel
    {
        public string? Name { get; set; }
        public int StarsNumber { get; set; }
        public int RoomsNumber { get; set; }

        public int CityId { get; set; }
    }
}
