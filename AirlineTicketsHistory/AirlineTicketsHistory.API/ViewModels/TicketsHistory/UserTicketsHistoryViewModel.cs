using AirlineTicketsHistory.API.ViewModels.AirlineTicket;

namespace AirlineTicketsHistory.API.ViewModels.TicketsHistory
{
    public class UserTicketsHistoryViewModel
    {
        public string? UserId { get; set; }
        public List<AirlineTicketViewModel>? AirlineTickets { get; set; }
    }
}
