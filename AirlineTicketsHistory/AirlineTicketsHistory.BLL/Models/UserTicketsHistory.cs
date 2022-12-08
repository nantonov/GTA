namespace AirlineTicketsHistory.BLL.Models
{
    public class UserTicketsHistory
    {
        public string? UserId { get; set; }
        public List<AirlineTicket>? AirlineTickets { get; set; }
    }
}
