using AirlineTickets.Data.Entities;

namespace AirlineTickets.Data.Interfaces
{
    public interface IAirlineTicketCityRepository : IGenericRepository<AirlineTicketCityEntity>
    {
        public Task<AirlineTicketCityEntity?> GetById(int ticketId, int cityId, CancellationToken cancellationToken);

        public Task Delete(int ticketId, int cityId, CancellationToken cancellationToken);
    }
}
