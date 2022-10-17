namespace AirlineTickets.Data.Tests.Tests
{
    public class AirlineTicketRepositoryTests : DataTestsHelpers
    {
        private readonly IGenericRepository<AirlineTicketEntity> _ticketRepository;

        public AirlineTicketRepositoryTests()
        {
            _ticketRepository = new AirlineTicketRepository(_context);
        }

        [Fact]
        public async Task Create_WhenTicketEntityIsSet_ShouldCreateNewTicket()
        {
            var initialTicket = TestEntitiesGenerator.GetAirlineTicketEntity();

            await _ticketRepository.Create(initialTicket, default);

            var resultTicket = await _ticketRepository.GetById(initialTicket.Id, default);
            resultTicket.ShouldNotBeNull();

            await _context.Database.EnsureDeletedAsync();
        }

        [Fact]
        public async Task Delete_WhenIdIsIncorrect_ShouldNotDeleteTicket()
        {
            var initialTicket = TestEntitiesGenerator.GetAirlineTicketEntity();
            await _ticketRepository.Create(initialTicket, default);

            await _ticketRepository.Delete(initialTicket.Id + 1, default);

            var resultTicket = await _ticketRepository.GetById(initialTicket.Id, default);
            resultTicket.ShouldNotBeNull();

            await _context.Database.EnsureDeletedAsync();
        }

        [Fact]
        public async Task Delete_WhenIdIsCorrect_ShouldDeleteTicket()
        {
            var initialTicket = TestEntitiesGenerator.GetAirlineTicketEntity();
            await _ticketRepository.Create(initialTicket, default);

            _context.Entry(initialTicket).State = EntityState.Detached;
            await _ticketRepository.Delete(initialTicket.Id, default);

            var resultTicket = await _ticketRepository.GetById(initialTicket.Id, default);
            resultTicket.ShouldBeNull();

            await _context.Database.EnsureDeletedAsync();

        }

        [Fact]
        public async Task GetAll_WhenNoTicketsExist_ShouldReturnEmptyList()
        {
            var initialList = await _ticketRepository.GetAll(default);

            initialList.ShouldBeEmpty(); 
            
            await _context.Database.EnsureDeletedAsync();
        }

        [Fact]
        public async Task GetAll_WhenTicketsExist_ShouldReturnListWithTickets()
        {
            var initialList = TestEntitiesGenerator.GetAirlineTicketEntityList();
            foreach (var ticket in initialList)
            {
                await _ticketRepository.Create(ticket, default);
            }

            var resultList = await _ticketRepository.GetAll(default);

            resultList.ShouldNotBeEmpty();
            resultList.Count().ShouldBeEquivalentTo(initialList.Count());

            await _context.Database.EnsureDeletedAsync();
        }

        [Fact]
        public async Task GetById_WhenIdIsIncorrect_ShouldNotReturnTicket()
        {
            var initialTicket = TestEntitiesGenerator.GetAirlineTicketEntity();
            await _ticketRepository.Create(initialTicket, default);

            var resultTicket = await _ticketRepository.GetById(initialTicket.Id + 1, default);

            resultTicket.ShouldBeNull();

            await _context.Database.EnsureDeletedAsync();
        }

        [Fact]
        public async Task GetById_WhenIdIsCorrect_ShouldReturnTicket()
        {
            var initialTicket = TestEntitiesGenerator.GetAirlineTicketEntity();
            await _ticketRepository.Create(initialTicket, default);

            var resultTicket = await _ticketRepository.GetById(initialTicket.Id, default);

            resultTicket.ShouldNotBeNull();

            await _context.Database.EnsureDeletedAsync();
        }

        [Fact]
        public async Task Update_WhenTicketEntityIsSet_ShouldUpdateTicket()
        {
            var initialTicket = TestEntitiesGenerator.GetAirlineTicketEntity();
            await _ticketRepository.Create(initialTicket, default);

            initialTicket.PassengerCredentials += " New Info";
            var resultTicket = await _ticketRepository.Update(initialTicket, default);

            resultTicket.PassengerCredentials.ShouldBe(initialTicket.PassengerCredentials);

            await _context.Database.EnsureDeletedAsync();
        }
    }
}