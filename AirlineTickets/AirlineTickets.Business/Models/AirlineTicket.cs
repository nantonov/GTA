namespace AirlineTickets.Business.Models
{
    public class AirlineTicket
    {
        public int Id { get; set; }
        public DateTime DepartureTime { get; set; }
        public DateTime ArrivalTime { get; set; }
        public int Price { get; set; }
        public string? PassengerCredentials { get; set; }

        public ICollection<AirlineTicketCity>? AirlineTicketCities { get; set; }
    }
}
