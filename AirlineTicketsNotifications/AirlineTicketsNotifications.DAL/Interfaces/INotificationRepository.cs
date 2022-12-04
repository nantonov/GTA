using AirlineTicketsNotifications.Core.Enums;
using AirlineTicketsNotifications.DAL.Entities;

namespace AirlineTicketsNotifications.DAL.Interfaces
{
    public interface INotificationRepository
    {
        public Task<NotificationRequestEntity> CreateNotificationRequest(NotificationRequestEntity createRequest,
            CancellationToken cancellationToken);

        public Task<IEnumerable<NotificationRequestEntity>> GetNotificationRequests(string cityName,
            CityStayingStatus stayingStatus, CancellationToken cancellationToken);
    }
}
