namespace AirlineTickets.Business.Tests.Tests
{
    public class AirlineTicketCityServiceTests
    {
        private readonly Mock<IAirlineTicketCityRepository> _ticketCityRepository;
        private readonly Mock<IMapper> _mapper;
        private readonly IAirlineTicketCityService _ticketCityService;

        public AirlineTicketCityServiceTests()
        {
            _ticketCityRepository = new Mock<IAirlineTicketCityRepository>();
            _mapper = new Mock<IMapper>();
            _ticketCityService = new AirlineTicketCityService(_ticketCityRepository.Object, _mapper.Object);
        }

        [Fact]
        public async Task Create_WhenTicketCityModelIsSet_ShouldReturnCorrectTicketCity()
        {
            _mapper.Setup(m => m.Map<AirlineTicketCityEntity>(AirlineTicketCityModels.TicketCityModel))
                .Returns(AirlineTicketCityEntities.TicketCityEntity);
            _ticketCityRepository.Setup(r => r.Create(AirlineTicketCityEntities.TicketCityEntity, default))
                .ReturnsAsync(AirlineTicketCityEntities.TicketCityEntity);
            _mapper.Setup(m => m.Map<AirlineTicketCity>(AirlineTicketCityEntities.TicketCityEntity))
                .Returns(AirlineTicketCityModels.TicketCityModel);

            var result = await _ticketCityService.Create(AirlineTicketCityModels.TicketCityModel, default);

            result.StayingStatus.ShouldBe(AirlineTicketCityModels.TicketCityModel.StayingStatus);
        }

        [Fact]
        public async Task Delete_WhenEntityNotExist_ShouldReturnNull()
        {
            _ticketCityRepository.Setup(r => r.GetById(AirlineTicketCityModels.TicketCityModel.AirlineTicketId,
                AirlineTicketCityModels.TicketCityModel.CityId, default)).ReturnsAsync(value: null);

            var result = await _ticketCityService.Delete(AirlineTicketCityModels.TicketCityModel.AirlineTicketId, 
                AirlineTicketCityModels.TicketCityModel.CityId, default);

            result.ShouldBeNull();
        }

        [Fact]
        public async Task Delete_WhenIdIsSet_ShouldReturnModel()
        {
            _ticketCityRepository.Setup(r => r.GetById(AirlineTicketCityModels.TicketCityModel.AirlineTicketId, 
                AirlineTicketCityModels.TicketCityModel.CityId, default)).ReturnsAsync(AirlineTicketCityEntities.TicketCityEntity);
            _ticketCityRepository.Setup(r => r.Delete(AirlineTicketCityModels.TicketCityModel.AirlineTicketId,
                AirlineTicketCityModels.TicketCityModel.CityId, default));
            _mapper.Setup(m => m.Map<AirlineTicketCity>(AirlineTicketCityEntities.TicketCityEntity))
                .Returns(AirlineTicketCityModels.TicketCityModel);

            var result = await _ticketCityService.Delete(AirlineTicketCityModels.TicketCityModel.AirlineTicketId, 
                AirlineTicketCityModels.TicketCityModel.CityId, default);

            result.StayingStatus.ShouldBe(AirlineTicketCityModels.TicketCityModel.StayingStatus);
        }

        [Fact]
        public async Task Get_WhenEntityNotExist_ShouldReturnNull()
        {
            _ticketCityRepository.Setup(r => r.GetById(AirlineTicketCityModels.TicketCityModel.AirlineTicketId, 
                AirlineTicketCityModels.TicketCityModel.CityId, default)).ReturnsAsync(value: null);

            var result = await _ticketCityService.Get(AirlineTicketCityModels.TicketCityModel.AirlineTicketId, 
                AirlineTicketCityModels.TicketCityModel.CityId, default);

            result.ShouldBeNull();
        }

        [Fact]
        public async Task Get_WhenEntityExist_ShouldReturnModel()
        {
            _ticketCityRepository.Setup(r => r.GetById(AirlineTicketCityModels.TicketCityModel.AirlineTicketId, 
                AirlineTicketCityModels.TicketCityModel.CityId, default)).ReturnsAsync(AirlineTicketCityEntities.TicketCityEntity);
            _mapper.Setup(m => m.Map<AirlineTicketCity>(AirlineTicketCityEntities.TicketCityEntity))
                .Returns(AirlineTicketCityModels.TicketCityModel);

            var result = await _ticketCityService.Get(AirlineTicketCityModels.TicketCityModel.AirlineTicketId, 
                AirlineTicketCityModels.TicketCityModel.CityId, default);

            result.StayingStatus.ShouldBe(AirlineTicketCityModels.TicketCityModel.StayingStatus);
        }

        [Fact]
        public async Task GetAll_WhenEntitiesExist_ShouldReturnListOfModels()
        {
            _ticketCityRepository.Setup(r => r.GetAll(default)).ReturnsAsync(AirlineTicketCityEntities.TicketCityEntitiesList);
            _mapper.Setup(m => m.Map<IEnumerable<AirlineTicketCity>>(AirlineTicketCityEntities.TicketCityEntitiesList))
                .Returns(AirlineTicketCityModels.TicketCityModelsList);

            var result = await _ticketCityService.GetAll(default);

            result.Count().ShouldBe(3);
        }

        [Fact]
        public async Task Update_WhenTicketModelIsSet_ShouldReturnCorrectModel()
        {
            _mapper.Setup(m => m.Map<AirlineTicketCityEntity>(AirlineTicketCityModels.TicketCityModel))
                .Returns(AirlineTicketCityEntities.TicketCityEntity);
            _ticketCityRepository.Setup(r => r.Update(AirlineTicketCityEntities.TicketCityEntity, default))
                .ReturnsAsync(AirlineTicketCityEntities.TicketCityEntity);
            _mapper.Setup(m => m.Map<AirlineTicketCity>(AirlineTicketCityEntities.TicketCityEntity))
                .Returns(AirlineTicketCityModels.TicketCityModel);

            var result = await _ticketCityService.Update(AirlineTicketCityModels.TicketCityModel, default);

            result.StayingStatus.ShouldBe(AirlineTicketCityModels.TicketCityModel.StayingStatus);
        }
    }
}
