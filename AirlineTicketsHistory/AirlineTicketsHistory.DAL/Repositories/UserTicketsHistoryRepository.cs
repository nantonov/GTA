using AirlineTicketsHistory.DAL.Entities;
using AirlineTicketsHistory.DAL.Interfaces;
using MongoDB.Driver;

namespace AirlineTicketsHistory.DAL.Repositories
{
    public class UserTicketsHistoryRepository : IUserTicketsHistoryRepository
    {
        private readonly IMongoDbContext _context;
        private readonly IMongoCollection<UserTicketsHistoryEntity> _tickets;

        public UserTicketsHistoryRepository(IMongoDbContext context)
        {
            _context = context;
            _tickets = _context.UserTicketsCollection;
        }

        public async Task<UserTicketsHistoryEntity> Create(UserTicketsHistoryEntity history, CancellationToken cancellationToken)
        {
            await _tickets.InsertOneAsync(history, cancellationToken: cancellationToken);
            return history;
        }

        public async Task Delete(string userId, CancellationToken cancellationToken)
        {
            var filter = Builders<UserTicketsHistoryEntity>.Filter.Eq(ticket => ticket.UserId, userId);

            await _tickets.DeleteOneAsync(filter, cancellationToken);
        }

        public async Task<IEnumerable<UserTicketsHistoryEntity>> GetAll(CancellationToken cancellationToken)
        {
            return await _tickets.AsQueryable().ToListAsync(cancellationToken);
        }

        public async Task<UserTicketsHistoryEntity> GetByUserId(string userId, CancellationToken cancellationToken)
        {
            var filter = Builders<UserTicketsHistoryEntity>.Filter.Eq(ticket => ticket.UserId, userId);

            return await (await _tickets.FindAsync(filter, cancellationToken: cancellationToken)).FirstOrDefaultAsync(cancellationToken);
        }

        public async Task<UserTicketsHistoryEntity> Update(UserTicketsHistoryEntity history, CancellationToken cancellationToken)
        {
            var filter = Builders<UserTicketsHistoryEntity>.Filter.Eq(ticket => ticket.UserId, history.UserId);

            await _tickets.ReplaceOneAsync(filter, history, cancellationToken: cancellationToken);

            return history;
        }
    }
}
