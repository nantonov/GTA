namespace AirlineTickets.Data.Entities
{
    public class HotelEntity
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int StarsNumber { get; set; }
        public int RoomsNumber { get; set; }
        public CityEntity? City { get; set; }
    }
}
