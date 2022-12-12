namespace AirlineTicketsNotifications.BLL.Tests.Tests
{
    public class NotificationServiceTests
    {
        private readonly Mock<INotificationRepository> _notificationRepository;
        private readonly Mock<IMapper> _mapper;
        private readonly Mock<IEmailService> _mailService;
        private readonly INotificationService _notificationService;

        public NotificationServiceTests()
        {
            _notificationRepository = new Mock<INotificationRepository>();
            _mapper = new Mock<IMapper>();
            _mailService = new Mock<IEmailService>();
            _notificationService = new NotificationService(_notificationRepository.Object, _mapper.Object, _mailService.Object);
        }

        [Fact]
        public async Task CreateNotificationRequest_WhenRequestModelIsSet_ShouldReturnCorrectRequest()
        {
            _mapper.Setup(m => m.Map<NotificationRequestEntity>(NotificationRequestModels.NotificationModel))
                .Returns(NotificationRequestEntities.NotificationEntity);
            _notificationRepository.Setup(r => r.CreateNotificationRequest(NotificationRequestEntities.NotificationEntity, default))
                .ReturnsAsync(NotificationRequestEntities.NotificationEntity);
            _mapper.Setup(m => m.Map<NotificationRequest>(NotificationRequestEntities.NotificationEntity))
                .Returns(NotificationRequestModels.NotificationModel);

            var result = await _notificationService.CreateNotificationRequest(NotificationRequestModels.NotificationModel, default);

            result.CityName.ShouldBe(NotificationRequestModels.NotificationModel.CityName);
            result.Email.ShouldBe(NotificationRequestModels.NotificationModel.Email);
            result.StayingStatus.ShouldBe(NotificationRequestModels.NotificationModel.StayingStatus);
        }
    }
}