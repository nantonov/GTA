using AirlineTicketsNotifications.API.Messages;
using AirlineTicketsNotifications.BLL.Interfaces;
using AirlineTicketsNotifications.BLL.Models.TicketInfo;
using AutoMapper;
using FluentValidation;
using MassTransit;

namespace AirlineTicketsNotifications.API.Consumers
{
    public class HandleNewTicketEventConsumer : IConsumer<NewTicketInfoMessage>
    {
        private readonly INotificationService _notificationService;
        private readonly IMapper _mapper;
        private readonly IValidator<NewTicketInfoMessage> _ticketInfoValidator;

        public HandleNewTicketEventConsumer(INotificationService notificationService, IMapper mapper,
            IValidator<NewTicketInfoMessage> ticketInfoValidator)
        {
            _notificationService = notificationService;
            _mapper = mapper;
            _ticketInfoValidator = ticketInfoValidator;
        }

        public async Task Consume(ConsumeContext<NewTicketInfoMessage> context)
        {
            var ticketInfo = context.Message;

            await _ticketInfoValidator.ValidateAndThrowAsync(ticketInfo);
            var model = _mapper.Map<NewTicketInfo>(ticketInfo);

            await _notificationService.HandleNewTicketEvent(model);
        }
    }
}
