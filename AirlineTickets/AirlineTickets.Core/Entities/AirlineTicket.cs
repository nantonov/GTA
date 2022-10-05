namespace AirlineTickets.Core.Entities
{
    public class AirlineTicket
    {
        public int Id { get; set; }
        public string? DeparturePlace { get; set; }
        public string? ArrivalPlace { get; set; }
        public DateTimeOffset DepartureTime { get; set; }
        public DateTimeOffset ArrivalTime { get; set; }
        public int Price { get; set; }
        public string? PassengerCredentials { get; set; }
    }
}