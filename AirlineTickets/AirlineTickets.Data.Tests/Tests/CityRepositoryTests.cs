namespace AirlineTickets.Data.Tests.Tests
{
    public class CityRepositoryTests : DataTestsHelpers
    {
        private readonly IGenericRepository<CityEntity> _repository;

        public CityRepositoryTests()
        {
            _repository = new CityRepository(_context);
        }

        [Fact]
        public async Task Create_WhenCityEntityIsSet_ShouldCreateNewCity()
        {
            var initialCity = TestEntitiesGenerator.GetCityEntity();

            await _repository.Create(initialCity, default);

            var resultCity = await _repository.GetById(initialCity.Id, default);
            resultCity.ShouldNotBeNull();

            await _context.Database.EnsureDeletedAsync();
        }

        [Fact]
        public async Task Delete_WhenIdIsIncorrect_ShouldNotDeleteCity()
        {
            var initialCity = TestEntitiesGenerator.GetCityEntity();
            await _repository.Create(initialCity, default);

            await _repository.Delete(initialCity.Id + 1, default);

            var resultCity = await _repository.GetById(initialCity.Id, default);
            resultCity.ShouldNotBeNull();

            await _context.Database.EnsureDeletedAsync();
        }

        [Fact]
        public async Task Delete_WhenIdIsCorrect_ShouldDeleteCity()
        {
            var initialCity = TestEntitiesGenerator.GetCityEntity();
            await _repository.Create(initialCity, default);

            _context.Entry(initialCity).State = EntityState.Detached;
            await _repository.Delete(initialCity.Id, default);

            var resultCity = await _repository.GetById(initialCity.Id, default);
            resultCity.ShouldBeNull();

            await _context.Database.EnsureDeletedAsync();

        }

        [Fact]
        public async Task GetAll_WhenNoCitiesExist_ShouldReturnEmptyList()
        {
            var initialList = await _repository.GetAll(default);

            initialList.ShouldBeEmpty();

            await _context.Database.EnsureDeletedAsync();
        }

        [Fact]
        public async Task GetAll_WhenCitiesExist_ShouldReturnListWithCities()
        {
            var initialList = TestEntitiesGenerator.GetCityEntityList();
            foreach (var city in initialList)
            {
                await _repository.Create(city, default);
            }

            var resultList = await _repository.GetAll(default);

            resultList.ShouldNotBeEmpty();
            resultList.Count().ShouldBeEquivalentTo(initialList.Count());

            await _context.Database.EnsureDeletedAsync();
        }

        [Fact]
        public async Task GetById_WhenIdIsIncorrect_ShouldNotReturnCity()
        {
            var initialCity = TestEntitiesGenerator.GetCityEntity();
            await _repository.Create(initialCity, default);

            var resultCity = await _repository.GetById(initialCity.Id + 1, default);

            resultCity.ShouldBeNull();

            await _context.Database.EnsureDeletedAsync();
        }

        [Fact]
        public async Task GetById_WhenIdIsCorrect_ShouldReturnCity()
        {
            var initialCity = TestEntitiesGenerator.GetCityEntity();
            await _repository.Create(initialCity, default);

            var resultCity = await _repository.GetById(initialCity.Id, default);

            resultCity.ShouldNotBeNull();

            await _context.Database.EnsureDeletedAsync();
        }

        [Fact]
        public async Task Update_WhenCityEntityIsSet_ShouldUpdateCity()
        {
            var initialCity = TestEntitiesGenerator.GetCityEntity();
            await _repository.Create(initialCity, default);

            initialCity.Name += " New Info";
            var resultCity = await _repository.Update(initialCity, default);

            resultCity.Name.ShouldBe(initialCity.Name);

            await _context.Database.EnsureDeletedAsync();
        }
    }
}
