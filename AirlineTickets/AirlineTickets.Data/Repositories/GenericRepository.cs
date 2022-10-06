using AirlineTickets.Data.Context;
using AirlineTickets.Data.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AirlineTickets.Data.Services
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly ApplicationDbContext _context;
        private readonly DbSet<T> _dbSet;

        public GenericRepository(ApplicationDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }

        public async Task Create(T obj, CancellationToken cancellationToken)
        {
            await _dbSet.AddAsync(obj, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task Delete(int id, CancellationToken cancellationToken)
        {
            _context.Remove(id);
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task<IEnumerable<T>> GetAll(CancellationToken cancellationToken)
        {
            return await _dbSet.AsNoTracking().ToListAsync(cancellationToken);
        }

        public async Task<T?> GetById(int id, CancellationToken cancellationToken)
        {
            return await _dbSet.FindAsync(id, cancellationToken);
        }

        public async Task Update(T obj, CancellationToken cancellationToken)
        {
            _context.Entry(obj).State = EntityState.Modified;
            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
