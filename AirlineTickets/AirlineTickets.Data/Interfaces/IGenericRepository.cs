namespace AirlineTickets.Data.Interfaces
{
    public interface IGenericRepository<T> where T : class
    {
        public Task<IEnumerable<T>> GetAllAsync();
        public Task<T?> GetByIdAsync(int id);
        public Task<int> CreateAsync(T obj);
        public Task<bool> UpdateAsync(T obj);
        public Task<bool> DeleteAsync(int id);
    }
}