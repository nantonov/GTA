namespace AirlineTicketsNotifications.DAL.Tests.Tests
{
    public class NotificationRepositoryTests : DataTestsHelpers
    {
        private readonly INotificationRepository _notificationRepository;

        public NotificationRepositoryTests()
        {
            _notificationRepository = new NotificationRepository(_context);
        }

        [Fact]
        public async Task CreateNotificationRequest_WhenNotificationEntityIsSet_ShouldCreateNewNotification()
        {
            var initialRequest = TestEntitiesGenerator.GetNotificationRequestEntity();
            var cityName = initialRequest.CityName;
            var stayingStatus = initialRequest.StayingStatus;

            await _notificationRepository.CreateNotificationRequest(initialRequest, default);

            var result = await _notificationRepository.GetNotificationRequests(cityName, stayingStatus, default);
            result.First().CityName.ShouldBe(initialRequest.CityName);
            result.First().StayingStatus.ShouldBe(initialRequest.StayingStatus);

            await _context.Database.EnsureDeletedAsync();
        }

        [Fact]
        public async Task GetNotificationRequests_WhenNoNotificationsExist_ShouldReturnEmptyList()
        {
            var initialList = await _notificationRepository.GetNotificationRequests(string.Empty, CityStayingStatus.Transit, default);

            initialList.ShouldBeEmpty();

            await _context.Database.EnsureDeletedAsync();
        }
    }
}