using Messages;

namespace AirlineTickets.DAL.External.Interfaces
{
    public interface IExternalService
    {
        Task PublishNewTicketInfo(NewTicketInfoMessage ticketInfo, CancellationToken cancellationToken);
    }
}
