using AirlineTickets.BLL.Interfaces;
using AirlineTickets.BLL.Models;
using AirlineTickets.DAL.External.Interfaces;
using AutoMapper;
using Messages;

namespace AirlineTickets.BLL.Services
{
    internal class MessageService : IMessageService
    {
        private readonly IExternalService _messageService;
        private readonly IMapper _mapper;

        public MessageService(IExternalService messageService, IMapper mapper)
        {
            _messageService = messageService;
            _mapper = mapper;
        }

        public async Task PublishNewTicketInfo(Message message, CancellationToken cancellationToken)
        {
            await _messageService.PublishNewTicketInfo(_mapper.Map<NewTicketInfoMessage>(message), cancellationToken);
        }
    }
}
