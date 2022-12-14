namespace AirlineTicketsHistory.BLL.Tests.Tests
{
    public class UserTicketsHistoryServiceTests
    {
        private readonly Mock<IUserTicketsHistoryRepository> _historyRepository;
        private readonly Mock<IMapper> _mapper;
        private readonly IUserTicketsHistoryService _historyService;

        public UserTicketsHistoryServiceTests()
        {
            _historyRepository = new Mock<IUserTicketsHistoryRepository>();
            _mapper = new Mock<IMapper>();
            _historyService = new UserTicketsHistoryService(_historyRepository.Object, _mapper.Object);
        }

        [Fact]
        public async Task AddTicketToUserHistory_WhenTicketIsSet_ShouldReturnUpdatedHistory()
        {
            string userId = UserTicketHistoryModels.HistoryModel.UserId ?? "user";
            var newHistory = UserTicketHistoryEntities.HistoryEntity ?? new UserTicketsHistoryEntity()
            {
                AirlineTickets = new List<AirlineTicketEntity>()
            };
            var ticket = new AirlineTicketEntity() { PassengerCredentials = "Passenger" };
            var newHistoryWithTicket = newHistory;
            newHistoryWithTicket.AirlineTickets?.Add(ticket);
            var newHistoryModel = UserTicketHistoryModels.HistoryModel ?? new UserTicketsHistory()
            {
                AirlineTickets = new List<AirlineTicket>()
            };
            var ticketModel = new AirlineTicket() { PassengerCredentials = "Passenger" };
            var newHistoryModelWithTicket = newHistoryModel;
            newHistoryModelWithTicket.AirlineTickets?.Add(ticketModel);
            _historyRepository.Setup(r => r.GetByUserId(userId, default)).ReturnsAsync(newHistory);
            _historyRepository.Setup(r => r.Update(It.IsAny<UserTicketsHistoryEntity>(), default)).ReturnsAsync(newHistoryWithTicket);
            _mapper.Setup(m => m.Map<UserTicketsHistory>(It.IsAny<UserTicketsHistoryEntity>())).Returns(newHistoryModelWithTicket);
            _mapper.Setup(m => m.Map<UserTicketsHistoryEntity>(It.IsAny<UserTicketsHistory>())).Returns(newHistory);

            var result = await _historyService.AddTicketToUserHistory(userId, ticketModel, default);

            result.ShouldNotBeNull();
            result?.AirlineTickets?.Count.ShouldBe(1);

        }

        [Fact]
        public async Task GetAll_WhenEntitiesExist_ShouldReturnListOfModels()
        {
            _historyRepository.Setup(r => r.GetAll(default)).ReturnsAsync(UserTicketHistoryEntities.HistoryEntitiesList);
            _mapper.Setup(m => m.Map<IEnumerable<UserTicketsHistory>>(UserTicketHistoryEntities.HistoryEntitiesList))
                .Returns(UserTicketHistoryModels.HistoryModelsList);

            var result = await _historyService.GetAll(default);

            result.Count().ShouldBe(3);
        }

        [Fact]
        public async Task GetByUserId_WhenEntityNotExist_ShouldReturnEmptyModel()
        {
            var emptyHistoryEntity = new UserTicketsHistoryEntity();
            var userId = UserTicketHistoryModels.HistoryModel.UserId ?? "user";
            _historyRepository.Setup(r => r.GetByUserId(userId, default)).ReturnsAsync(emptyHistoryEntity);

            var result = await _historyService.GetByUserId(userId, default);

            result.ShouldBeNull();
        }

        [Fact]
        public async Task GetByUserId_WhenEntityExist_ShouldReturnModel()
        {
            var userId = UserTicketHistoryModels.HistoryModel.UserId ?? "user";
            _historyRepository.Setup(r => r.GetByUserId(userId, default)).ReturnsAsync(UserTicketHistoryEntities.HistoryEntity);
            _mapper.Setup(m => m.Map<UserTicketsHistory>(UserTicketHistoryEntities.HistoryEntity))
                .Returns(UserTicketHistoryModels.HistoryModel);

            var result = await _historyService.GetByUserId(userId, default);

            result.UserId.ShouldBe(userId);
        }

        [Fact]
        public async Task RemoveTicketFromUserHistory_WhenIdsAreSet_ShouldReturnUpdatedHistory()
        {
            string userId = UserTicketHistoryModels.HistoryModel.UserId ?? "user";
            var newHistory = UserTicketHistoryEntities.HistoryEntity ?? new UserTicketsHistoryEntity()
            {
                AirlineTickets = new List<AirlineTicketEntity>()
            };
            var ticket = new AirlineTicketEntity() { TicketId = 1, PassengerCredentials = "Passenger" };
            var newHistoryWithTicket = newHistory;
            newHistoryWithTicket.AirlineTickets?.Add(ticket);
            var newHistoryModel = UserTicketHistoryModels.HistoryModel ?? new UserTicketsHistory()
            {
                AirlineTickets = new List<AirlineTicket>()
            };
            var ticketModel = new AirlineTicket() { TicketId = 1, PassengerCredentials = "Passenger" };
            var newHistoryModelWithTicket = newHistoryModel;
            newHistoryModelWithTicket.AirlineTickets?.Add(ticketModel);
            _historyRepository.Setup(r => r.GetByUserId(userId, default)).ReturnsAsync(newHistoryWithTicket);
            _historyRepository.Setup(r => r.Update(It.IsAny<UserTicketsHistoryEntity>(), default)).ReturnsAsync(newHistory);
            _mapper.Setup(m => m.Map<UserTicketsHistory>(It.IsAny<UserTicketsHistoryEntity>())).Returns(newHistoryModelWithTicket);
            _mapper.Setup(m => m.Map<UserTicketsHistoryEntity>(It.IsAny<UserTicketsHistory>())).Returns(newHistory);

            var result = await _historyService.RemoveTicketFromUserHistory(userId, ticketModel.TicketId, default);

            result.ShouldNotBeNull();
            result?.AirlineTickets?.Count.ShouldBe(0);
        }
    }
}