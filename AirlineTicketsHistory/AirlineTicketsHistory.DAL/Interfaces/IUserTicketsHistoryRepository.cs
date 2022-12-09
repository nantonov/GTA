using AirlineTicketsHistory.DAL.Entities;

namespace AirlineTicketsHistory.DAL.Interfaces
{
    public interface IUserTicketsHistoryRepository
    {
        Task<IEnumerable<UserTicketsHistoryEntity>> GetAll(CancellationToken cancellationToken);

        Task<UserTicketsHistoryEntity> GetByUserId(string userId, CancellationToken cancellationToken);

        Task<UserTicketsHistoryEntity> Create(UserTicketsHistoryEntity history, CancellationToken cancellationToken);

        Task<UserTicketsHistoryEntity> Update(UserTicketsHistoryEntity history, CancellationToken cancellationToken);

        Task Delete(string id, CancellationToken cancellationToken);
    }
}
