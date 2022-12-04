using AirlineTicketsNotifications.BLL.Interfaces;
using AirlineTicketsNotifications.BLL.Models.Requests;
using AirlineTicketsNotifications.BLL.Models.TicketInfo;
using AirlineTicketsNotifications.DAL.Entities;
using AirlineTicketsNotifications.DAL.Interfaces;
using AutoMapper;

namespace AirlineTicketsNotifications.BLL.Services
{
    internal class NotificationService : INotificationService
    {
        private readonly IEmailService _emailService;
        private readonly INotificationRepository _notificationRepository;
        private readonly IMapper _mapper;

        public NotificationService(INotificationRepository notificationRepository, IMapper mapper, IEmailService emailService)
        {
            _notificationRepository = notificationRepository;
            _mapper = mapper;
            _emailService = emailService;
        }

        public async Task<NotificationRequest> CreateNotificationRequest(NotificationRequest notificationRequest, CancellationToken cancellationToken)
        {
            return _mapper.Map<NotificationRequest>(await _notificationRepository.CreateNotificationRequest(
                _mapper.Map<NotificationRequestEntity>(notificationRequest), cancellationToken));
        }

        public async Task HandleNewTicketEvent(NewTicketInfo ticketInfo, CancellationToken cancellationToken)
        {
            var requests = _mapper.Map<IEnumerable<NotificationRequest>>(await _notificationRepository
                .GetNotificationRequests(ticketInfo.CityName, ticketInfo.StayingStatus, cancellationToken));

            foreach (var request in requests)
            {
                await _emailService.SendEmailMessage(request, cancellationToken);
            }
        }
    }
}
