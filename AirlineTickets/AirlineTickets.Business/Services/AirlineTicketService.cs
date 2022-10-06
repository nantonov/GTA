using AirlineTickets.Business.Interfaces;
using AirlineTickets.Core.Constants;
using AirlineTickets.Core.Entities;
using AirlineTickets.Core.Exceptions;
using AirlineTickets.Data.Interfaces;

namespace AirlineTickets.Business.Services
{
    public class AirlineTicketService : IGenericService<AirlineTicket>
    {
        private readonly IGenericRepository<AirlineTicket> _ticketRepository;

        public AirlineTicketService(IGenericRepository<AirlineTicket> ticketRepository)
        {
            this._ticketRepository = ticketRepository;
        }

        public async Task Create(AirlineTicket obj, CancellationToken cancellationToken) =>
            await _ticketRepository.Create(obj, cancellationToken);

        public async Task Delete(int id, CancellationToken cancellationToken)
        {
            var ticket = _ticketRepository.GetById(id, cancellationToken);

            if (ticket is null)
            {
                throw new AirlineTicketNullException(ExceptionMessages.AirlineTicketNotFoundMessage);
            }

            await _ticketRepository.Delete(id, cancellationToken);
        }

        public async Task<AirlineTicket> Get(int id, CancellationToken cancellationToken)
        {
            var ticket = await _ticketRepository.GetById(id, cancellationToken);

            if (ticket is null)
            {
                throw new AirlineTicketNullException(ExceptionMessages.AirlineTicketNotFoundMessage);
            }

            return ticket;
        }

        public async Task<IEnumerable<AirlineTicket>> GetAll(CancellationToken cancellationToken) =>
            await _ticketRepository.GetAll(cancellationToken);

        public async Task Update(AirlineTicket obj, CancellationToken cancellationToken)
        {
            var ticket = await _ticketRepository.GetById(obj.Id, cancellationToken);

            if (ticket is null)
            {
                throw new AirlineTicketNullException(ExceptionMessages.AirlineTicketNotFoundMessage);
            }

            await _ticketRepository.Update(obj, cancellationToken);
        }
    }
}
