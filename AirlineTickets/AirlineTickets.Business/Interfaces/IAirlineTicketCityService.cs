using AirlineTickets.Business.Models;

namespace AirlineTickets.Business.Interfaces
{
    public interface IAirlineTicketCityService : IGenericService<AirlineTicketCity>
    {
        public Task<AirlineTicketCity> Delete(int ticketId, int cityId, CancellationToken cancellationToken);

        public Task<AirlineTicketCity> Get(int ticketId, int cityId, CancellationToken cancellationToken);
    }
}
