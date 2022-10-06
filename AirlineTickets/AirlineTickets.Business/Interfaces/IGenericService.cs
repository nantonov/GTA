namespace AirlineTickets.Business.Interfaces
{
    public interface IGenericService<T> where T : class
    {
        Task Create(T obj, CancellationToken cancellationToken);

        Task Delete(int id, CancellationToken cancellationToken);

        Task<T> Get(int id, CancellationToken cancellationToken);

        Task<IEnumerable<T>> GetAll(CancellationToken cancellationToken);

        Task Update(T obj, CancellationToken cancellationToken);
    }
}
