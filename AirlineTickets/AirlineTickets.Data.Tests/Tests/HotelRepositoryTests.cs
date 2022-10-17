namespace AirlineTickets.Data.Tests.Tests
{
    public class HotelRepositoryTests : DataTestsHelpers
    {
        private readonly IGenericRepository<HotelEntity> _repository;

        public HotelRepositoryTests()
        {
            _repository = new HotelRepository(_context);
        }

        [Fact]
        public async Task Create_WhenHotelEntityIsSet_ShouldCreateNewHotel()
        {
            var initialHotel = TestEntitiesGenerator.GetHotelEntity();

            await _repository.Create(initialHotel, default);

            var resultHotel = await _repository.GetById(initialHotel.Id, default);
            resultHotel.ShouldNotBeNull();

            await _context.Database.EnsureDeletedAsync();
        }

        [Fact]
        public async Task Delete_WhenIdIsIncorrect_ShouldNotDeleteHotel()
        {
            var initialHotel = TestEntitiesGenerator.GetHotelEntity();
            await _repository.Create(initialHotel, default);

            await _repository.Delete(initialHotel.Id + 1, default);

            var resultHotel = await _repository.GetById(initialHotel.Id, default);
            resultHotel.ShouldNotBeNull();

            await _context.Database.EnsureDeletedAsync();
        }

        [Fact]
        public async Task Delete_WhenIdIsCorrect_ShouldDeleteHotel()
        {
            var initialHotel = TestEntitiesGenerator.GetHotelEntityWithoutCity();
            await _repository.Create(initialHotel, default);

            await _repository.Delete(initialHotel.Id, default);

            var resultHotel = await _repository.GetById(initialHotel.Id, default);
            resultHotel.ShouldBeNull();

            await _context.Database.EnsureDeletedAsync();

        }

        [Fact]
        public async Task GetAll_WhenNoHotelsExist_ShouldReturnEmptyList()
        {
            var initialList = await _repository.GetAll(default);

            initialList.ShouldBeEmpty();

            await _context.Database.EnsureDeletedAsync();
        }

        [Fact]
        public async Task GetAll_WhenHotelsExist_ShouldReturnListWithHotels()
        {
            var initialList = TestEntitiesGenerator.GetHotelEntityList();
            foreach (var hotel in initialList)
            {
                await _repository.Create(hotel, default);
            }

            var resultList = await _repository.GetAll(default);

            resultList.ShouldNotBeEmpty();
            resultList.Count().ShouldBeEquivalentTo(initialList.Count());

            await _context.Database.EnsureDeletedAsync();
        }

        [Fact]
        public async Task GetById_WhenIdIsIncorrect_ShouldNotReturnHotel()
        {
            var initialHotel = TestEntitiesGenerator.GetHotelEntity();
            await _repository.Create(initialHotel, default);

            var resultHotel = await _repository.GetById(initialHotel.Id + 1, default);

            resultHotel.ShouldBeNull();

            await _context.Database.EnsureDeletedAsync();
        }

        [Fact]
        public async Task GetById_WhenIdIsCorrect_ShouldReturnHotel()
        {
            var initialHotel = TestEntitiesGenerator.GetHotelEntity();
            await _repository.Create(initialHotel, default);

            var resultHotel = await _repository.GetById(initialHotel.Id, default);

            resultHotel.ShouldNotBeNull();

            await _context.Database.EnsureDeletedAsync();
        }

        [Fact]
        public async Task Update_WhenHotelEntityIsSet_ShouldUpdateHotel()
        {
            var initialHotel = TestEntitiesGenerator.GetHotelEntity();
            await _repository.Create(initialHotel, default);

            initialHotel.Name += " New Info";
            var resultHotel = await _repository.Update(initialHotel, default);

            resultHotel.Name.ShouldBe(initialHotel.Name);

            await _context.Database.EnsureDeletedAsync();
        }
    }
}
