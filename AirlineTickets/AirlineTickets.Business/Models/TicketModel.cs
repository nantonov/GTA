namespace AirlineTickets.Business.Models
{
    public class TicketModel
    {
        public int Id { get; set; }
        public string? DeparturePlace { get; set; }
        public string? ArrivalPlace { get; set; }
        public DateTime DepartureTime { get; set; }
        public DateTime ArrivalTime { get; set; }
        public int Price { get; set; }
        public string? PassengerCredentials { get; set; }
    }
}
