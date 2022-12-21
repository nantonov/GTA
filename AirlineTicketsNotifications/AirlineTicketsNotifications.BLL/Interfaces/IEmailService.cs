using AirlineTicketsNotifications.BLL.Models.Requests;

namespace AirlineTicketsNotifications.BLL.Interfaces
{
    public interface IEmailService
    {
        public Task SendEmailMessage(NotificationRequest notificationRequest);
    }
}
