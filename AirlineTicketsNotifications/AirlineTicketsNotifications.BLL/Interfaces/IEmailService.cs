using AirlineTicketsNotifications.BLL.Models.Requests;
using AirlineTicketsNotifications.Core.Enums;

namespace AirlineTicketsNotifications.BLL.Interfaces
{
    public interface IEmailService
    {
        public Task SendEmailMessage(NotificationRequest notificationRequest, CancellationToken cancellationToken);
    }
}
