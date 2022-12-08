using AirlineTicketsHistory.BLL.Models;

namespace AirlineTicketsHistory.BLL.Interfaces
{
    public interface IUserTicketsHistoryService
    {
        Task<UserTicketsHistory> AddTicketToUserHistory(string userId, AirlineTicket ticket, CancellationToken cancellationToken);

        Task<UserTicketsHistory> RemoveTicketFromUserHistory(string userId, int ticketId, CancellationToken cancellationToken);

        Task<UserTicketsHistory> Delete(string userId, CancellationToken cancellationToken);

        Task<UserTicketsHistory> GetByUserId(string userId, CancellationToken cancellationToken);

        Task<IEnumerable<UserTicketsHistory>> GetAll(CancellationToken cancellationToken);
    }
}
