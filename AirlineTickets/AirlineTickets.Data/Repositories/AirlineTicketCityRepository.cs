using AirlineTickets.Data.Context;
using AirlineTickets.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace AirlineTickets.Data.Repositories
{
    public class AirlineTicketCityRepository : GenericRepository<AirlineTicketCity>
    {
        public AirlineTicketCityRepository(ApplicationDbContext context) : base(context) { }

        public override async Task<IEnumerable<AirlineTicketCity>> GetAll(CancellationToken cancellationToken) =>
            await _dbSet.AsNoTracking().Include(tc => tc.City).Include(tc => tc.AirlineTicket).ToListAsync(cancellationToken);

        public override async Task<AirlineTicketCity?> GetById(int id, CancellationToken cancellationToken) =>
            await _dbSet.AsNoTracking().Include(h => h.City).Include(tc => tc.AirlineTicket)
            .FirstOrDefaultAsync(tc => tc.AirlineTicketId == id && tc.CityId == id, cancellationToken);
    }
}
