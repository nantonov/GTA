using AirlineTicketsNotifications.BLL.Models.Requests;
using AirlineTicketsNotifications.BLL.Models.TicketInfo;

namespace AirlineTicketsNotifications.BLL.Interfaces
{
    public interface INotificationService
    {
        public Task<NotificationRequest> CreateNotificationRequest(NotificationRequest notificationRequest, CancellationToken cancellationToken);

        public Task HandleNewTicketEvent(NewTicketInfo ticketInfo, CancellationToken cancellationToken);
    }
}
