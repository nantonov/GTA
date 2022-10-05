namespace AirlineTickets.Data.Interfaces
{
    public interface IGenericRepository<T> where T : class
    {
        public Task<IEnumerable<T>> GetAllAsync();
        public Task<T?> GetByIdAsync(int id);
        public Task CreateAsync(T obj);
        public Task UpdateAsync(T obj);
        public Task DeleteAsync(int id);
    }
}