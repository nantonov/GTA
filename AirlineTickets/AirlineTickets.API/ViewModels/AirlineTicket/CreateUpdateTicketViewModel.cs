namespace AirlineTickets.API.ViewModels.AirlineTicket
{
    public class CreateUpdateTicketViewModel
    {
        public DateTime DepartureTime { get; set; }
        public DateTime ArrivalTime { get; set; }
        public int Price { get; set; }
        public string? PassengerCredentials { get; set; }
    }
}
