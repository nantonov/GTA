using AirlineTickets.Data.Context;
using AirlineTickets.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace AirlineTickets.Data.Repositories
{
    public class AirlineTicketCityRepository : GenericRepository<AirlineTicketCityEntity>
    {
        public AirlineTicketCityRepository(ApplicationDbContext context) : base(context) { }

        public override async Task<IEnumerable<AirlineTicketCityEntity>> GetAll(CancellationToken cancellationToken) =>
            await _dbSet.AsNoTracking().Include(tc => tc.City).Include(tc => tc.AirlineTicket).ToListAsync(cancellationToken);

        public override async Task<AirlineTicketCityEntity?> GetById(int id, CancellationToken cancellationToken) =>
            await _dbSet.AsNoTracking().Include(h => h.City).Include(tc => tc.AirlineTicket)
            .FirstOrDefaultAsync(tc => tc.AirlineTicketId == id && tc.CityId == id, cancellationToken);
    }
}
