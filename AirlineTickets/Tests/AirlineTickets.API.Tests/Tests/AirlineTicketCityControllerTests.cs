namespace AirlineTickets.API.Tests.Tests
{
    public class AirlineTicketCityControllerTests : APITestsBase
    {
        [Fact]
        public async Task GetAll_WhenTicketCitiesExist_ShouldReturnTicketCitiesWithOkStatusCode()
        {
            await _context.Database.EnsureDeletedAsync();

            _context.AirlineTickets.AddRange(AirlineTicketEntities.TicketEntitiesList);
            _context.Cities.AddRange(CityEntities.CityEntitiesList);
            _context.AirlineTicketCities.AddRange(AirlineTicketCityEntities.TicketCityEntitiesList);
            await _context.SaveChangesAsync();

            var response = await _httpClient.GetAsync(RequestUris.DefaultTicketCityUri);
            var result = await response.Content.ReadAsAsync<List<AirlineTicketCityEntity>>();

            response.StatusCode.ShouldBeEquivalentTo(HttpStatusCode.OK);
            result.ShouldNotBeEmpty();
        }

        [Fact]
        public async Task GetById_WhenTicketCityNotExist_ShouldNotReturnTicketCityWithNoContentStatusCode()
        {
            await _context.Database.EnsureDeletedAsync();

            var response = await _httpClient.GetAsync(RequestUris.GetDeleteTicketCityUri);
            var result = await response.Content.ReadAsAsync<AirlineTicketEntity>();

            response.StatusCode.ShouldBeEquivalentTo(HttpStatusCode.NoContent);
            result.ShouldBeNull();
        }

        [Fact]
        public async Task GetById_WhenTicketCityExist_ShouldReturnTicketCityWithOkStatusCode()
        {
            await _context.Database.EnsureDeletedAsync();

            _context.AirlineTickets.Add(AirlineTicketEntities.TicketEntity);
            _context.Cities.Add(CityEntities.CityEntity);
            _context.AirlineTicketCities.Add(AirlineTicketCityEntities.TicketCityEntity);
            await _context.SaveChangesAsync();

            var response = await _httpClient.GetAsync(RequestUris.GetDeleteTicketCityUri);
            var result = await response.Content.ReadAsAsync<AirlineTicketCityEntity>();

            response.StatusCode.ShouldBeEquivalentTo(HttpStatusCode.OK);
            result.StayingStatus.ShouldBe(AirlineTicketCityEntities.TicketCityEntity.StayingStatus);
        }

        [Fact]
        public async Task Create_WhenTicketCityViewModelIsSet_ShouldReturnCorrectTicketCityWithOkStatusCode()
        {
            await _context.Database.EnsureDeletedAsync();

            var response = await _httpClient.PostAsync(RequestUris.DefaultTicketCityUri,
                SerializeObjectToHttpContent(AirlineTicketCityEntities.TicketCityEntity));
            var result = await response.Content.ReadAsAsync<AirlineTicketCityEntity>();

            response.StatusCode.ShouldBeEquivalentTo(HttpStatusCode.OK);
            result.ShouldNotBeNull();
        }

        [Fact]
        public async Task Delete_WhenTicketCityNotExist_ShouldReturnNullWithOkStatusCode()
        {
            await _context.Database.EnsureDeletedAsync();

            var response = await _httpClient.DeleteAsync(RequestUris.GetDeleteTicketCityUri);
            var result = await response.Content.ReadAsAsync<AirlineTicketCityEntity>();

            response.StatusCode.ShouldBeEquivalentTo(HttpStatusCode.OK);
            result.ShouldBeNull();
        }

        [Fact]
        public async Task Delete_WhenIdIsSet_ShouldReturnOkStatusCode()
        {
            await _context.Database.EnsureDeletedAsync();

            _context.AirlineTickets.Add(AirlineTicketEntities.TicketEntity);
            _context.Cities.Add(CityEntities.CityEntity);
            _context.AirlineTicketCities.Add(AirlineTicketCityEntities.TicketCityEntity);
            await _context.SaveChangesAsync();

            var response = await _httpClient.DeleteAsync(RequestUris.GetDeleteTicketCityUri);

            response.StatusCode.ShouldBeEquivalentTo(HttpStatusCode.OK);
        }

        [Fact]
        public async Task Update_WhenTicketCityNotExist_ShouldReturnInternalServerErrorStatusCode()
        {
            await _context.Database.EnsureDeletedAsync();

            var response = await _httpClient.PutAsync(RequestUris.DefaultTicketCityUri,
                SerializeObjectToHttpContent(AirlineTicketCityEntities.TicketCityEntity));

            response.StatusCode.ShouldBeEquivalentTo(HttpStatusCode.InternalServerError);
        }

        [Fact]
        public async Task Update_WhenTicketCityExist_ShouldReturnUpdatedTicketWithOkStatusCode()
        {
            await _context.Database.EnsureDeletedAsync();

            _context.AirlineTicketCities.Add(AirlineTicketCityEntities.TicketCityEntity);
            await _context.SaveChangesAsync();
            var ticketCityToUpdate = AirlineTicketCityEntities.TicketCityEntity;
            ticketCityToUpdate.StayingStatus = Core.Enums.CityStayingStatus.Departure;

            var response = await _httpClient.PutAsync(RequestUris.DefaultTicketCityUri,
                SerializeObjectToHttpContent(ticketCityToUpdate));
            var result = await response.Content.ReadAsAsync<AirlineTicketCityEntity>();

            response.StatusCode.ShouldBeEquivalentTo(HttpStatusCode.OK);
            result.StayingStatus.ShouldBe(ticketCityToUpdate.StayingStatus);
        }
    }
}
