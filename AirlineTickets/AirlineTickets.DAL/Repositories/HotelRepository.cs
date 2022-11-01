using AirlineTickets.DAL.Context;
using AirlineTickets.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace AirlineTickets.DAL.Repositories
{
    public class HotelRepository : GenericRepository<HotelEntity>
    {
        public HotelRepository(ApplicationDbContext context) : base(context) { }

        public override async Task<IEnumerable<HotelEntity>> GetAll(CancellationToken cancellationToken) =>
            await _dbSet.AsNoTracking().Include(h => h.City).ToListAsync(cancellationToken);

        public override async Task<HotelEntity?> GetById(int id, CancellationToken cancellationToken) =>
            await _dbSet.AsNoTracking().Include(h => h.City).FirstOrDefaultAsync(h => h.Id == id, cancellationToken);
    }
}
