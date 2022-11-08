namespace AirlineTickets.BLL.Tests.Tests
{
    public class AirlineTicketServiceTests
    {
        private readonly Mock<IGenericRepository<AirlineTicketEntity>> _ticketRepository;
        private readonly Mock<IMapper> _mapper;
        private readonly IGenericService<AirlineTicket> _ticketService;

        public AirlineTicketServiceTests()
        {
            _ticketRepository = new Mock<IGenericRepository<AirlineTicketEntity>>();
            _mapper = new Mock<IMapper>();
            _ticketService = new GenericService<AirlineTicket, AirlineTicketEntity>(_ticketRepository.Object, _mapper.Object);
        }

        [Fact]
        public async Task Create_WhenTicketModelIsSet_ShouldReturnCorrectTicket()
        {
            _mapper.Setup(m => m.Map<AirlineTicketEntity>(AirlineTicketModels.TicketModel))
                .Returns(AirlineTicketEntities.TicketEntity);
            _ticketRepository.Setup(r => r.Create(AirlineTicketEntities.TicketEntity, default))
                .ReturnsAsync(AirlineTicketEntities.TicketEntity);
            _mapper.Setup(m => m.Map<AirlineTicket>(AirlineTicketEntities.TicketEntity))
                .Returns(AirlineTicketModels.TicketModel);

            var result = await _ticketService.Create(AirlineTicketModels.TicketModel, default);

            result.Price.ShouldBe(AirlineTicketModels.TicketModel.Price);
            result.PassengerCredentials.ShouldBe(AirlineTicketModels.TicketModel.PassengerCredentials);
        }

        [Fact]
        public async Task Delete_WhenEntityNotExist_ShouldReturnNull()
        {
            _ticketRepository.Setup(r => r.GetById(AirlineTicketModels.TicketModel.Id, default)).ReturnsAsync(value: null);

            var result = await _ticketService.Delete(AirlineTicketModels.TicketModel.Id, default);

            result.ShouldBeNull();
        }

        [Fact]
        public async Task Delete_WhenEntityExist_ShouldReturnModel()
        {
            _ticketRepository.Setup(r => r.GetById(AirlineTicketModels.TicketModel.Id, default))
                .ReturnsAsync(AirlineTicketEntities.TicketEntity);
            _ticketRepository.Setup(r => r.Delete(AirlineTicketModels.TicketModel.Id, default));
            _mapper.Setup(m => m.Map<AirlineTicket>(AirlineTicketEntities.TicketEntity))
                .Returns(AirlineTicketModels.TicketModel);

            var result = await _ticketService.Delete(AirlineTicketModels.TicketModel.Id, default);

            result.Price.ShouldBe(AirlineTicketModels.TicketModel.Price);
            result.PassengerCredentials.ShouldBe(AirlineTicketModels.TicketModel.PassengerCredentials);
        }

        [Fact]
        public async Task Get_WhenEntityNotExist_ShouldReturnNull()
        {
            _ticketRepository.Setup(r => r.GetById(AirlineTicketModels.TicketModel.Id, default))
                .ReturnsAsync(value: null);

            var result = await _ticketService.Get(AirlineTicketModels.TicketModel.Id, default);

            result.ShouldBeNull();
        }

        [Fact]
        public async Task Get_WhenEntityExist_ShouldReturnModel()
        {
            _ticketRepository.Setup(r => r.GetById(AirlineTicketModels.TicketModel.Id, default))
                .ReturnsAsync(AirlineTicketEntities.TicketEntity);
            _mapper.Setup(m => m.Map<AirlineTicket>(AirlineTicketEntities.TicketEntity))
                .Returns(AirlineTicketModels.TicketModel);

            var result = await _ticketService.Get(AirlineTicketModels.TicketModel.Id, default);

            result.Price.ShouldBe(AirlineTicketModels.TicketModel.Price);
            result.PassengerCredentials.ShouldBe(AirlineTicketModels.TicketModel.PassengerCredentials);
        }

        [Fact]
        public async Task GetAll_WhenEntitiesExist_ShouldReturnListOfModels()
        {
            _ticketRepository.Setup(r => r.GetAll(default)).ReturnsAsync(AirlineTicketEntities.TicketEntitiesList);
            _mapper.Setup(m => m.Map<IEnumerable<AirlineTicket>>(AirlineTicketEntities.TicketEntitiesList))
                .Returns(AirlineTicketModels.TicketModelsList);

            var result = await _ticketService.GetAll(default);

            result.Count().ShouldBe(3);
        }

        [Fact]
        public async Task Update_WhenTicketModelIsSet_ShouldReturnCorrectModel()
        {
            _mapper.Setup(m => m.Map<AirlineTicketEntity>(AirlineTicketModels.TicketModel))
                .Returns(AirlineTicketEntities.TicketEntity);
            _ticketRepository.Setup(r => r.Update(AirlineTicketEntities.TicketEntity, default))
                .ReturnsAsync(AirlineTicketEntities.TicketEntity);
            _mapper.Setup(m => m.Map<AirlineTicket>(AirlineTicketEntities.TicketEntity))
                .Returns(AirlineTicketModels.TicketModel);

            var result = await _ticketService.Update(AirlineTicketModels.TicketModel, default);

            result.Price.ShouldBe(AirlineTicketModels.TicketModel.Price);
            result.PassengerCredentials.ShouldBe(AirlineTicketModels.TicketModel.PassengerCredentials);
        }
    }
}
