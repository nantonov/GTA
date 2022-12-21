using AirlineTickets.BLL.Models;

namespace AirlineTickets.BLL.Interfaces
{
    public interface IMessageService
    {
        Task PublishNewTicketInfo(Message message, CancellationToken cancellationToken);
    }
}
