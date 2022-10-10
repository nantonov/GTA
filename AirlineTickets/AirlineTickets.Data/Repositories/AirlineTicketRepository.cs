using AirlineTickets.Data.Context;
using AirlineTickets.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace AirlineTickets.Data.Repositories
{
    public class AirlineTicketRepository : GenericRepository<AirlineTicketEntity>
    {
        public AirlineTicketRepository(ApplicationDbContext context) : base(context) { }

        public override async Task<IEnumerable<AirlineTicketEntity>> GetAll(CancellationToken cancellationToken) =>
            await _dbSet.AsNoTracking().Include(t => t.AirlineTicketCities).ToListAsync(cancellationToken);

        public override async Task<AirlineTicketEntity?> GetById(int id, CancellationToken cancellationToken) =>
            await _dbSet.AsNoTracking().Include(t => t.AirlineTicketCities)
                .FirstOrDefaultAsync(t => t.Id == id, cancellationToken);
    }
}
