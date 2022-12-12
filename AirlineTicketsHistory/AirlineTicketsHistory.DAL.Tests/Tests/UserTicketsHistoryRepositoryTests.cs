namespace AirlineTicketsHistory.DAL.Tests.Tests
{
    public class UserTicketsHistoryRepositoryTests : DataTestsHelpers
    {
        private readonly IUserTicketsHistoryRepository _historyRepository;

        public UserTicketsHistoryRepositoryTests()
        {
            _historyRepository = new UserTicketsHistoryRepository(_context);
        }

        [Fact]
        public async Task Create_WhenHistoryEntityIsSet_ShouldCreateNewHistoryEntityAsync()
        {
            var initialHistory = TestEntitiesGenerator.GetUserTicketsHistoryEntity();
            var userId = initialHistory.UserId ?? "user";

            if (await _historyRepository.GetByUserId(userId, default) is null)
            {
                await _historyRepository.Create(initialHistory, default);
            }

            var resultHistory = await _historyRepository.GetByUserId(userId, default);

            resultHistory.ShouldNotBeNull();
        }

        [Fact]
        public async Task GetAll_WhenHistoryExist_ShouldReturnListWithHistory()
        {
            var initialHistory = TestEntitiesGenerator.GetUserTicketsHistoryEntity();
            var userId = initialHistory.UserId ?? "user";
            var count = 1;
            if (await _historyRepository.GetByUserId(userId, default) is null)
            {
                await _historyRepository.Create(initialHistory, default);
            }

            var resultList = await _historyRepository.GetAll(default);

            resultList.ShouldNotBeEmpty();
            resultList.Count().ShouldBeEquivalentTo(count);
        }

        [Fact]
        public async Task GetByUserId_WhenIdIsCorrect_ShouldReturnHistory()
        {
            var initialHistory = TestEntitiesGenerator.GetUserTicketsHistoryEntity();
            var userId = initialHistory.UserId ?? "user";
            if (await _historyRepository.GetByUserId(userId, default) is null)
            {
                await _historyRepository.Create(initialHistory, default);
            }

            var resultHistory = await _historyRepository.GetByUserId(userId, default);

            resultHistory.ShouldNotBeNull();
        }

        [Fact]
        public async Task Update_WhenHistoryEntityIsSet_ShouldUpdateHistory()
        {
            var initialHistory = TestEntitiesGenerator.GetUserTicketsHistoryEntity();
            var userId = initialHistory.UserId ?? "user";
            if (await _historyRepository.GetByUserId(userId, default) is null)
            {
                await _historyRepository.Create(initialHistory, default);
            }
            var ticket = new AirlineTicketEntity();
            var count = 1;

            initialHistory?.AirlineTickets?.Add(ticket);
            var resultHistory = await _historyRepository.Update(initialHistory ?? new UserTicketsHistoryEntity(), default);

            resultHistory?.AirlineTickets?.Count.ShouldBe(count);
        }
    }
}