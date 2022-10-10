using AirlineTickets.Data.Context;
using AirlineTickets.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace AirlineTickets.Data.Repositories
{
    public class CityRepository : GenericRepository<CityEntity>
    {
        public CityRepository(ApplicationDbContext context) : base(context) { }

        public override async Task<IEnumerable<CityEntity>> GetAll(CancellationToken cancellationToken) =>
            await _dbSet.AsNoTracking().Include(c => c.Hotels).Include(c => c.AirlineTicketCities).ToListAsync(cancellationToken);

        public override async Task<CityEntity?> GetById(int id, CancellationToken cancellationToken) =>
            await _dbSet.AsNoTracking().Include(c => c.Hotels).Include(c => c.AirlineTicketCities)
                .FirstOrDefaultAsync(c => c.Id == id, cancellationToken);
    }
}
