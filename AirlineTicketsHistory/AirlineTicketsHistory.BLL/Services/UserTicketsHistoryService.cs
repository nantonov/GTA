using AirlineTicketsHistory.BLL.Interfaces;
using AirlineTicketsHistory.BLL.Models;
using AirlineTicketsHistory.DAL.Entities;
using AirlineTicketsHistory.DAL.Interfaces;
using AutoMapper;

namespace AirlineTicketsHistory.BLL.Services
{
    internal class UserTicketsHistoryService : IUserTicketsHistoryService
    {
        private readonly IUserTicketsHistoryRepository _historyRepository;
        private readonly IMapper _mapper;

        public UserTicketsHistoryService(IUserTicketsHistoryRepository historyRepository, IMapper mapper)
        {
            _historyRepository = historyRepository;
            _mapper = mapper;
        }

        public async Task<UserTicketsHistory> AddTicketToUserHistory(string userId, AirlineTicket ticket, CancellationToken cancellationToken)
        {
            var historyModel = _mapper.Map<UserTicketsHistory>(await _historyRepository.GetByUserId(userId, cancellationToken));

            historyModel ??= new UserTicketsHistory()
            {
                UserId = userId,
                AirlineTickets = new List<AirlineTicket>()
            };

            historyModel.AirlineTickets?.Add(ticket);

            UserTicketsHistoryEntity history = await _historyRepository.GetByUserId(userId, cancellationToken);

            if (history is null)
            {
                history = await _historyRepository.Create(_mapper.Map<UserTicketsHistoryEntity>(historyModel), cancellationToken);
            }
            else
            {
                history = await _historyRepository.Update(_mapper.Map<UserTicketsHistoryEntity>(historyModel), cancellationToken);
            }

            return _mapper.Map<UserTicketsHistory>(history);
        }

        public async Task<UserTicketsHistory> Delete(string userId, CancellationToken cancellationToken)
        {
            var historyModel = await _historyRepository.GetByUserId(userId, cancellationToken);

            if (historyModel is not null)
            {
                await _historyRepository.Delete(userId, cancellationToken);
            }

            return _mapper.Map<UserTicketsHistory>(historyModel);
        }

        public async Task<IEnumerable<UserTicketsHistory>> GetAll(CancellationToken cancellationToken) =>
            _mapper.Map<IEnumerable<UserTicketsHistory>>(await _historyRepository.GetAll(cancellationToken));

        public async Task<UserTicketsHistory> GetByUserId(string userId, CancellationToken cancellationToken) =>
            _mapper.Map<UserTicketsHistory>(await _historyRepository.GetByUserId(userId, cancellationToken));

        public async Task<UserTicketsHistory> RemoveTicketFromUserHistory(string userId, int ticketId, CancellationToken cancellationToken)
        {
            var historyModel = _mapper.Map<UserTicketsHistory>(await _historyRepository.GetByUserId(userId, cancellationToken));

            if (historyModel?.AirlineTickets is null)
            {
                return new UserTicketsHistory();
            }

            var ticket = historyModel.AirlineTickets?.Where(t => t.TicketId == ticketId).FirstOrDefault();

            if (ticket is not null)
            {
                historyModel.AirlineTickets?.Remove(ticket);
            }

            await _historyRepository.Update(_mapper.Map<UserTicketsHistoryEntity>(historyModel), cancellationToken);

            return historyModel;
        }
    }
}
