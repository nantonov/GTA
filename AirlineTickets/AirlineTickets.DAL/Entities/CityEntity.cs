namespace AirlineTickets.DAL.Entities
{
    public class CityEntity
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int Population { get; set; }
        public int Area { get; set; }

        public ICollection<AirlineTicketCityEntity>? AirlineTicketCities { get; set; }
        public ICollection<HotelEntity>? Hotels { get; set; }
    }
}
