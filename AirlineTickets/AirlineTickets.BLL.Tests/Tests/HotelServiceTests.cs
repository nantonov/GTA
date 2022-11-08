namespace AirlineTickets.BLL.Tests.Tests
{
    public class HotelServiceTests
    {
        private readonly Mock<IGenericRepository<HotelEntity>> _hotelRepository;
        private readonly Mock<IMapper> _mapper;
        private readonly IGenericService<Hotel> _hotelService;

        public HotelServiceTests()
        {
            _hotelRepository = new Mock<IGenericRepository<HotelEntity>>();
            _mapper = new Mock<IMapper>();
            _hotelService = new GenericService<Hotel, HotelEntity>(_hotelRepository.Object, _mapper.Object);
        }

        [Fact]
        public async Task Create_WhenHotelModelIsSet_ShouldReturnCorrectHotel()
        {
            _mapper.Setup(m => m.Map<HotelEntity>(HotelModels.HotelModel)).Returns(HotelEntities.HotelEntity);
            _hotelRepository.Setup(r => r.Create(HotelEntities.HotelEntity, default)).ReturnsAsync(HotelEntities.HotelEntity);
            _mapper.Setup(m => m.Map<Hotel>(HotelEntities.HotelEntity)).Returns(HotelModels.HotelModel);

            var result = await _hotelService.Create(HotelModels.HotelModel, default);

            result.Name.ShouldBe(HotelModels.HotelModel.Name);
        }

        [Fact]
        public async Task Delete_WhenEntityNotExist_ShouldReturnNull()
        {
            _hotelRepository.Setup(r => r.GetById(HotelModels.HotelModel.Id, default)).ReturnsAsync(value: null);

            var result = await _hotelService.Delete(HotelModels.HotelModel.Id, default);

            result.ShouldBeNull();
        }

        [Fact]
        public async Task Delete_WhenEntityExist_ShouldReturnModel()
        {
            _hotelRepository.Setup(r => r.GetById(HotelModels.HotelModel.Id, default)).ReturnsAsync(HotelEntities.HotelEntity);
            _hotelRepository.Setup(r => r.Delete(HotelModels.HotelModel.Id, default));
            _mapper.Setup(m => m.Map<Hotel>(HotelEntities.HotelEntity)).Returns(HotelModels.HotelModel);

            var result = await _hotelService.Delete(HotelModels.HotelModel.Id, default);

            result.Name.ShouldBe(HotelModels.HotelModel.Name);
        }

        [Fact]
        public async Task Get_WhenEntityNotExist_ShouldReturnNull()
        {
            _hotelRepository.Setup(r => r.GetById(HotelModels.HotelModel.Id, default)).ReturnsAsync(value: null);

            var result = await _hotelService.Get(HotelModels.HotelModel.Id, default);

            result.ShouldBeNull();
        }

        [Fact]
        public async Task Get_WhenEntityExist_ShouldReturnModel()
        {
            _hotelRepository.Setup(r => r.GetById(HotelModels.HotelModel.Id, default)).ReturnsAsync(HotelEntities.HotelEntity);
            _mapper.Setup(m => m.Map<Hotel>(HotelEntities.HotelEntity)).Returns(HotelModels.HotelModel);

            var result = await _hotelService.Get(HotelModels.HotelModel.Id, default);

            result.Name.ShouldBe(HotelModels.HotelModel.Name);
        }

        [Fact]
        public async Task GetAll_WhenEntitiesExist_ShouldReturnListOfModels()
        {
            _hotelRepository.Setup(r => r.GetAll(default)).ReturnsAsync(HotelEntities.HotelEntitiesList);
            _mapper.Setup(m => m.Map<IEnumerable<Hotel>>(HotelEntities.HotelEntitiesList)).Returns(HotelModels.HotelModelsList);

            var result = await _hotelService.GetAll(default);

            result.Count().ShouldBe(3);
        }

        [Fact]
        public async Task Update_WhenHotelModelIsSet_ShouldReturnCorrectModel()
        {
            _mapper.Setup(m => m.Map<HotelEntity>(HotelModels.HotelModel)).Returns(HotelEntities.HotelEntity);
            _hotelRepository.Setup(r => r.Update(HotelEntities.HotelEntity, default)).ReturnsAsync(HotelEntities.HotelEntity);
            _mapper.Setup(m => m.Map<Hotel>(HotelEntities.HotelEntity)).Returns(HotelModels.HotelModel);

            var result = await _hotelService.Update(HotelModels.HotelModel, default);

            result.Name.ShouldBe(HotelModels.HotelModel.Name);
        }
    }
}