namespace AirlineTickets.Data.Tests.Tests
{
    public class AirlineTicketCityRepositoryTests : DataTestsHelpers
    {
        private readonly IAirlineTicketCityRepository _ticketCityRepository;

        public AirlineTicketCityRepositoryTests()
        {
            _ticketCityRepository = new AirlineTicketCityRepository(_context);
        }

        [Fact]
        public async Task Create_WhenTicketCityEntityIsSet_ShouldCreateNewTicketCity()
        {
            var initialTicketCity = TestEntitiesGenerator.GetAirlineTicketCityEntity();

            await _ticketCityRepository.Create(initialTicketCity, default);

            var resultTicketCity = await _ticketCityRepository.GetById(initialTicketCity.AirlineTicketId,
                initialTicketCity.CityId, default);
            resultTicketCity.ShouldNotBeNull();

            await _context.Database.EnsureDeletedAsync();
        }

        [Fact]
        public async Task Delete_WhenIdIsIncorrect_ShouldNotDeleteTicketCity()
        {
            var initialTicketCity = TestEntitiesGenerator.GetAirlineTicketCityEntity();
            await _ticketCityRepository.Create(initialTicketCity, default);

            await _ticketCityRepository.Delete(initialTicketCity.AirlineTicketId + 1, initialTicketCity.CityId + 1, default);

            var resultTicketCity = await _ticketCityRepository.GetById(initialTicketCity.AirlineTicketId, 
                initialTicketCity.CityId, default);
            resultTicketCity.ShouldNotBeNull();

            await _context.Database.EnsureDeletedAsync();
        }

        [Fact]
        public async Task Delete_WhenIdIsCorrect_ShouldDeleteTicketCity()
        {
            var initialTicketCity = TestEntitiesGenerator.GetAirlineTicketCityEntityWithoutCitiesAndTickets();
            await _ticketCityRepository.Create(initialTicketCity, default);

            await _ticketCityRepository.Delete(initialTicketCity.AirlineTicketId, initialTicketCity.CityId, default);

            var resultTicketCity = await _ticketCityRepository.GetById(initialTicketCity.AirlineTicketId, 
                initialTicketCity.CityId, default);
            resultTicketCity.ShouldBeNull();

            await _context.Database.EnsureDeletedAsync();
        }

        [Fact]
        public async Task GetAll_WhenNoTicketCitiesExist_ShouldReturnEmptyList()
        {
            var initialList = await _ticketCityRepository.GetAll(default);

            initialList.ShouldBeEmpty();

            await _context.Database.EnsureDeletedAsync();
        }

        [Fact]
        public async Task GetAll_WhenTicketCitiesExist_ShouldReturnListWithTicketCities()
        {
            var initialList = TestEntitiesGenerator.GetAirlineTicketCityEntityList();

            foreach (var ticketCity in initialList)
            {
                await _ticketCityRepository.Create(ticketCity, default);
            }

            var resultList = await _ticketCityRepository.GetAll(default);

            resultList.ShouldNotBeEmpty();
            resultList.Count().ShouldBeEquivalentTo(initialList.Count());

            await _context.Database.EnsureDeletedAsync();
        }

        [Fact]
        public async Task GetById_WhenIdIsIncorrect_ShouldNotReturnTicketCity()
        {
            var initialTicketCity = TestEntitiesGenerator.GetAirlineTicketCityEntity();
            await _ticketCityRepository.Create(initialTicketCity, default);

            var resultTicketCity = await _ticketCityRepository.GetById(initialTicketCity.AirlineTicketId + 1, 
                initialTicketCity.CityId + 1, default);

            resultTicketCity.ShouldBeNull();

            await _context.Database.EnsureDeletedAsync();
        }

        [Fact]
        public async Task GetById_WhenIdIsCorrect_ShouldReturnTicketCity()
        {
            var initialTicketCity = TestEntitiesGenerator.GetAirlineTicketCityEntity();
            await _ticketCityRepository.Create(initialTicketCity, default);

            var resultTicketCity = await _ticketCityRepository.GetById(initialTicketCity.AirlineTicketId, 
                initialTicketCity.CityId, default);

            resultTicketCity.ShouldNotBeNull();

            await _context.Database.EnsureDeletedAsync();
        }

        [Fact]
        public async Task Update_WhenTicketCityEntityIsSet_ShouldUpdateTicketCity()
        {
            var initialTicketCity = TestEntitiesGenerator.GetAirlineTicketCityEntity();
            await _ticketCityRepository.Create(initialTicketCity, default);

            if (initialTicketCity.StayingStatus == Core.Enums.CityStayingStatus.Arrival)
            {
                initialTicketCity.StayingStatus = Core.Enums.CityStayingStatus.Departure;
            }
            else
            {
                initialTicketCity.StayingStatus = Core.Enums.CityStayingStatus.Arrival;
            }
            await _ticketCityRepository.Update(initialTicketCity, default);
            var resultTicketCity = await _ticketCityRepository.GetById(initialTicketCity.AirlineTicketId, 
                initialTicketCity.CityId, default);

            resultTicketCity?.StayingStatus.ShouldBe(initialTicketCity.StayingStatus);

            await _context.Database.EnsureDeletedAsync();
        }
    }
}
