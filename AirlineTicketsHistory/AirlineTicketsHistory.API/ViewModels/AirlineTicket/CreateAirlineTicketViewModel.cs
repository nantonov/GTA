namespace AirlineTicketsHistory.API.ViewModels.AirlineTicket
{
    public class CreateAirlineTicketViewModel
    {
        public string? UserId { get; set; }
        public int TicketId { get; set; }
        public DateTime DepartureTime { get; set; }
        public DateTime ArrivalTime { get; set; }
        public int Price { get; set; }
        public string? PassengerCredentials { get; set; }
    }
}
