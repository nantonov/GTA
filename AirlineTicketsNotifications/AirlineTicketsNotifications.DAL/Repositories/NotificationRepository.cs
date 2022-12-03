using AirlineTicketsNotifications.Core.Enums;
using AirlineTicketsNotifications.DAL.Context;
using AirlineTicketsNotifications.DAL.Entities;
using AirlineTicketsNotifications.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AirlineTicketsNotifications.DAL.Repositories
{
    public class NotificationRepository : INotificationRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly DbSet<NotificationRequestEntity> _notificationRequests;

        public NotificationRepository(ApplicationDbContext context)
        {
            _context = context;
            _notificationRequests = _context.NotificationRequests;
        }

        public async Task<NotificationRequestEntity> CreateNotificationRequest(NotificationRequestEntity createRequest,
            CancellationToken cancellationToken)
        {
            await _notificationRequests.AddAsync(createRequest, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
            return createRequest;
        }

        public async Task<IEnumerable<NotificationRequestEntity>> GetNotificationRequests(string cityName,
            CityStayingStatus stayingStatus, CancellationToken cancellationToken)
        {
            return await _notificationRequests.AsNoTracking().Where(r => r.StayingStatus == stayingStatus
                && r.CityName.Equals(cityName)).ToListAsync(cancellationToken);
        }
    }
}
