namespace AirlineTickets.Business.Tests.Tests
{
    public class CityServiceTests
    {
        private readonly Mock<IGenericRepository<CityEntity>> _cityRepository;
        private readonly Mock<IMapper> _mapper;
        private readonly IGenericService<City> _cityService;

        public CityServiceTests()
        {
            _cityRepository = new Mock<IGenericRepository<CityEntity>>();
            _mapper = new Mock<IMapper>();
            _cityService = new GenericService<City, CityEntity>(_cityRepository.Object, _mapper.Object);
        }

        [Fact]
        public async Task Create_WhenCityModelIsSet_ShouldReturnCorrectCity()
        {
            _mapper.Setup(m => m.Map<CityEntity>(CityModels.CityModel)).Returns(CityEntities.CityEntity);
            _cityRepository.Setup(r => r.Create(CityEntities.CityEntity, default)).ReturnsAsync(CityEntities.CityEntity);
            _mapper.Setup(m => m.Map<City>(CityEntities.CityEntity)).Returns(CityModels.CityModel);

            var result = await _cityService.Create(CityModels.CityModel, default);

            result.Name.ShouldBe(CityModels.CityModel.Name);
        }

        [Fact]
        public async Task Delete_WhenEntityNotExist_ShouldReturnNull()
        {
            _cityRepository.Setup(r => r.GetById(CityModels.CityModel.Id, default)).ReturnsAsync(value: null);

            var result = await _cityService.Delete(CityModels.CityModel.Id, default);

            result.ShouldBeNull();
        }

        [Fact]
        public async Task Delete_WhenEntityExist_ShouldReturnModel()
        {
            _cityRepository.Setup(r => r.GetById(CityModels.CityModel.Id, default)).ReturnsAsync(CityEntities.CityEntity);
            _cityRepository.Setup(r => r.Delete(CityModels.CityModel.Id, default));
            _mapper.Setup(m => m.Map<City>(CityEntities.CityEntity)).Returns(CityModels.CityModel);

            var result = await _cityService.Delete(CityModels.CityModel.Id, default);

            result.Name.ShouldBe(CityModels.CityModel.Name);
        }

        [Fact]
        public async Task Get_WhenEntityNotExist_ShouldReturnNull()
        {
            _cityRepository.Setup(r => r.GetById(CityModels.CityModel.Id, default)).ReturnsAsync(value: null);

            var result = await _cityService.Get(CityModels.CityModel.Id, default);

            result.ShouldBeNull();
        }

        [Fact]
        public async Task Get_WhenEntityExist_ShouldReturnModel()
        {
            _cityRepository.Setup(r => r.GetById(CityModels.CityModel.Id, default)).ReturnsAsync(CityEntities.CityEntity);
            _mapper.Setup(m => m.Map<City>(CityEntities.CityEntity)).Returns(CityModels.CityModel);

            var result = await _cityService.Get(CityModels.CityModel.Id, default);

            result.Name.ShouldBe(CityModels.CityModel.Name);
        }

        [Fact]
        public async Task GetAll_WhenEntitiesExist_ShouldReturnListOfModels()
        {
            _cityRepository.Setup(r => r.GetAll(default)).ReturnsAsync(CityEntities.CityEntitiesList);
            _mapper.Setup(m => m.Map<IEnumerable<City>>(CityEntities.CityEntitiesList)).Returns(CityModels.CityModelsList);

            var result = await _cityService.GetAll(default);

            result.Count().ShouldBe(3);
        }

        [Fact]
        public async Task Update_WhenCityModelIsSet_ShouldReturnCorrectModel()
        {
            _mapper.Setup(m => m.Map<CityEntity>(CityModels.CityModel)).Returns(CityEntities.CityEntity);
            _cityRepository.Setup(r => r.Update(CityEntities.CityEntity, default)).ReturnsAsync(CityEntities.CityEntity);
            _mapper.Setup(m => m.Map<City>(CityEntities.CityEntity)).Returns(CityModels.CityModel);

            var result = await _cityService.Update(CityModels.CityModel, default);

            result.Name.ShouldBe(CityModels.CityModel.Name);
        }
    }
}
