namespace AirlineTickets.Data.Entities
{
    public class AirlineTicketEntity
    {
        public int Id { get; set; }
        public DateTime DepartureTime { get; set; }
        public DateTime ArrivalTime { get; set; }
        public int Price { get; set; }
        public string? PassengerCredentials { get; set; }

        public ICollection<AirlineTicketCityEntity>? AirlineTicketCities { get; set; }
    }
}