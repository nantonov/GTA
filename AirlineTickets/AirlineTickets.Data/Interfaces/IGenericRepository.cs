namespace AirlineTickets.Data.Interfaces
{
    public interface IGenericRepository<T> where T : class
    {
        public Task<IEnumerable<T>> GetAll(CancellationToken cancellationToken);
        public Task<T?> GetById(int id, CancellationToken cancellationToken);
        public Task Create(T obj, CancellationToken cancellationToken);
        public Task Update(T obj, CancellationToken cancellationToken);
        public Task Delete(int id, CancellationToken cancellationToken);
    }
}