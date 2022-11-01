using AirlineTickets.DAL.Context;
using AirlineTickets.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AirlineTickets.DAL.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected readonly ApplicationDbContext _context;
        protected readonly DbSet<T> _dbSet;

        public GenericRepository(ApplicationDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }

        public async Task<T> Create(T obj, CancellationToken cancellationToken)
        {
            await _dbSet.AddAsync(obj, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
            return obj;
        }

        public async Task Delete(int id, CancellationToken cancellationToken)
        {
            var entity = await GetById(id, cancellationToken);

            if (entity is not null)
            {
                _context.Remove(entity);
                await _context.SaveChangesAsync(cancellationToken);
            }
        }

        public virtual async Task<IEnumerable<T>> GetAll(CancellationToken cancellationToken)
        {
            return await _dbSet.AsNoTracking().ToListAsync(cancellationToken);
        }

        public virtual async Task<T?> GetById(int id, CancellationToken cancellationToken)
        {
            return await _dbSet.FindAsync(id, cancellationToken);
        }

        public async Task<T> Update(T obj, CancellationToken cancellationToken)
        {
            _context.Entry(obj).State = EntityState.Modified;
            await _context.SaveChangesAsync(cancellationToken);
            return obj;
        }
    }
}
