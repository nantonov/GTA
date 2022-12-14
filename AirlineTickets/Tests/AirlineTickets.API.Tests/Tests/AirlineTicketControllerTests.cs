namespace AirlineTickets.API.Tests.Tests
{
    public class AirlineTicketControllerTests : APITestsBase
    {
        [Fact]
        public async Task GetAll_WhenTicketsExist_ShouldReturnTicketsWithOkStatusCode()
        {
            await _context.Database.EnsureDeletedAsync();

            _context.AirlineTickets.AddRange(AirlineTicketEntities.TicketEntitiesList);
            await _context.SaveChangesAsync();

            var response = await _httpClient.GetAsync(RequestUris.DefaultTicketUri);
            var result = await response.Content.ReadAsAsync<List<AirlineTicketEntity>>();

            response.StatusCode.ShouldBeEquivalentTo(HttpStatusCode.OK);
            result.ShouldNotBeEmpty();
        }

        [Fact]
        public async Task GetById_WhenTicketNotExist_ShouldNotReturnTicketWithNoContentStatusCode()
        {
            await _context.Database.EnsureDeletedAsync();

            var response = await _httpClient.GetAsync(RequestUris.GetDeleteUpdateTicketUri);
            var result = await response.Content.ReadAsAsync<AirlineTicketEntity>();

            response.StatusCode.ShouldBeEquivalentTo(HttpStatusCode.NoContent);
            result.ShouldBeNull();
        }

        [Fact]
        public async Task GetById_WhenTicketExist_ShouldReturnTicketWithOkStatusCode()
        {
            await _context.Database.EnsureDeletedAsync();

            _context.AirlineTickets.Add(AirlineTicketEntities.TicketEntity);
            await _context.SaveChangesAsync();

            var response = await _httpClient.GetAsync(RequestUris.GetDeleteUpdateTicketUri);
            var result = await response.Content.ReadAsAsync<AirlineTicketEntity>();

            response.StatusCode.ShouldBeEquivalentTo(HttpStatusCode.OK);
            result.Price.ShouldBe(AirlineTicketEntities.TicketEntity.Price);
            result.PassengerCredentials.ShouldBe(AirlineTicketEntities.TicketEntity.PassengerCredentials);
        }

        [Fact]
        public async Task Create_WhenTicketViewModelIsSet_ShouldReturnCorrectTicketWithOkStatusCode()
        {
            await _context.Database.EnsureDeletedAsync();

            var response = await _httpClient.PostAsync(RequestUris.DefaultTicketUri,
                SerializeObjectToHttpContent(AirlineTicketEntities.TicketEntity));
            var result = await response.Content.ReadAsAsync<AirlineTicketEntity>();

            response.StatusCode.ShouldBeEquivalentTo(HttpStatusCode.OK);
            result.ShouldNotBeNull();
        }

        [Fact]
        public async Task Delete_WhenTicketNotExist_ShouldReturnNullWithOkStatusCode()
        {
            await _context.Database.EnsureDeletedAsync();

            var response = await _httpClient.DeleteAsync(RequestUris.GetDeleteUpdateTicketUri);
            var result = await response.Content.ReadAsAsync<AirlineTicketEntity>();

            response.StatusCode.ShouldBeEquivalentTo(HttpStatusCode.OK);
            result.ShouldBeNull();
        }

        [Fact]
        public async Task Delete_WhenIdIsSet_ShouldReturnOkStatusCode()
        {
            await _context.Database.EnsureDeletedAsync();

            _context.AirlineTickets.Add(AirlineTicketEntities.TicketEntity);
            await _context.SaveChangesAsync();

            var response = await _httpClient.DeleteAsync(RequestUris.GetDeleteUpdateTicketUri);

            response.StatusCode.ShouldBeEquivalentTo(HttpStatusCode.OK);
        }

        [Fact]
        public async Task Update_WhenTicketNotExist_ShouldReturnInternalServerErrorStatusCode()
        {
            await _context.Database.EnsureDeletedAsync();

            var response = await _httpClient.PutAsync(RequestUris.GetDeleteUpdateTicketUri,
                SerializeObjectToHttpContent(AirlineTicketEntities.TicketEntity));

            response.StatusCode.ShouldBeEquivalentTo(HttpStatusCode.InternalServerError);
        }

        [Fact]
        public async Task Update_WhenTicketExist_ShouldReturnUpdatedTicketWithOkStatusCode()
        {
            await _context.Database.EnsureDeletedAsync();

            _context.AirlineTickets.Add(AirlineTicketEntities.TicketEntity);
            await _context.SaveChangesAsync();
            var ticketToUpdate = AirlineTicketEntities.TicketEntity;
            ticketToUpdate.Price = 200;

            var response = await _httpClient.PutAsync(RequestUris.GetDeleteUpdateTicketUri, 
                SerializeObjectToHttpContent(ticketToUpdate));
            var result = await response.Content.ReadAsAsync<AirlineTicketEntity>();

            response.StatusCode.ShouldBeEquivalentTo(HttpStatusCode.OK);
            result.Price.ShouldBe(ticketToUpdate.Price);
        }
    }
}