namespace AirlineTickets.Business.Interfaces
{
    public interface IGenericService<T> where T : class
    {
        Task<T> Create(T obj, CancellationToken cancellationToken);

        Task<T> Delete(int id, CancellationToken cancellationToken);

        Task<T> Get(int id, CancellationToken cancellationToken);

        Task<IEnumerable<T>> GetAll(CancellationToken cancellationToken);

        Task<T> Update(T obj, CancellationToken cancellationToken);
    }
}
