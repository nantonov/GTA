using AirlineTickets.DAL.Context;
using AirlineTickets.DAL.Entities;
using AirlineTickets.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AirlineTickets.DAL.Repositories
{
    public class AirlineTicketCityRepository : GenericRepository<AirlineTicketCityEntity>, IAirlineTicketCityRepository
    {
        public AirlineTicketCityRepository(ApplicationDbContext context) : base(context) { }

        public override async Task<IEnumerable<AirlineTicketCityEntity>> GetAll(CancellationToken cancellationToken) =>
            await _dbSet.AsNoTracking().Include(tc => tc.City).Include(tc => tc.AirlineTicket).ToListAsync(cancellationToken);

        public async Task<AirlineTicketCityEntity?> GetById(int ticketId, int cityId, CancellationToken cancellationToken) =>
            await _dbSet.AsNoTracking().Include(h => h.City).Include(tc => tc.AirlineTicket)
            .FirstOrDefaultAsync(tc => tc.AirlineTicketId == ticketId && tc.CityId == cityId, cancellationToken);

        public async Task Delete(int ticketId, int cityId, CancellationToken cancellationToken)
        {
            var entity = await GetById(ticketId, cityId, cancellationToken);

            if (entity is not null)
            {
                _context.Remove(entity);
                await _context.SaveChangesAsync(cancellationToken);
            }
        }
    }
}
