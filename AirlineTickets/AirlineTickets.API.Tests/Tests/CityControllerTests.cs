namespace AirlineTickets.API.Tests.Tests
{
    public class CityControllerTests : APITestsBase
    {
        [Fact]
        public async Task GetAll_WhenCitiesExist_ShouldReturnCitiesWithOkStatusCode()
        {
            await _context.Database.EnsureDeletedAsync();

            _context.Cities.AddRange(CityEntities.CityEntitiesList);
            await _context.SaveChangesAsync();

            var response = await _httpClient.GetAsync(RequestUris.DefaultCityUri);

            response.StatusCode.ShouldBeEquivalentTo(HttpStatusCode.OK);
            var result = await response.Content.ReadAsAsync<List<CityEntity>>();
            result.ShouldNotBeEmpty();
        }

        [Fact]
        public async Task GetById_WhenCityNotExist_ShouldNotReturnCityWithNoContentStatusCode()
        {
            await _context.Database.EnsureDeletedAsync();

            var response = await _httpClient.GetAsync(RequestUris.GetDeleteUpdateCityUri);

            response.StatusCode.ShouldBeEquivalentTo(HttpStatusCode.NoContent);
            var result = await response.Content.ReadAsAsync<CityEntity>();
            result.ShouldBeNull();
        }

        [Fact]
        public async Task GetById_WhenCityExist_ShouldReturnCityWithOkStatusCode()
        {
            await _context.Database.EnsureDeletedAsync();

            _context.Cities.Add(CityEntities.CityEntity);
            await _context.SaveChangesAsync();

            var response = await _httpClient.GetAsync(RequestUris.GetDeleteUpdateCityUri);

            response.StatusCode.ShouldBeEquivalentTo(HttpStatusCode.OK);
            var result = await response.Content.ReadAsAsync<CityEntity>();
            result.Name.ShouldBe(CityEntities.CityEntity.Name);
            result.Population.ShouldBe(CityEntities.CityEntity.Population);
        }

        [Fact]
        public async Task Create_WhenCityViewModelIsSet_ShouldReturnCorrectCityWithOkStatusCode()
        {
            await _context.Database.EnsureDeletedAsync();

            var response = await _httpClient.PostAsync(RequestUris.DefaultCityUri,
                SerializeObjectToHttpContent(CityEntities.CityEntity));

            response.StatusCode.ShouldBeEquivalentTo(HttpStatusCode.OK);
            var result = await response.Content.ReadAsAsync<CityEntity>();
            result.ShouldNotBeNull();
        }

        [Fact]
        public async Task Delete_WhenCityNotExist_ShouldReturnNullWithOkStatusCode()
        {
            await _context.Database.EnsureDeletedAsync();

            var response = await _httpClient.DeleteAsync(RequestUris.GetDeleteUpdateCityUri);

            response.StatusCode.ShouldBeEquivalentTo(HttpStatusCode.OK);
            var result = await response.Content.ReadAsAsync<CityEntity>();
            result.ShouldBeNull();
        }

        [Fact]
        public async Task Delete_WhenIdIsSet_ShouldReturnOkStatusCode()
        {
            await _context.Database.EnsureDeletedAsync();

            _context.Cities.Add(CityEntities.CityEntity);
            await _context.SaveChangesAsync();

            var response = await _httpClient.DeleteAsync(RequestUris.GetDeleteUpdateCityUri);

            response.StatusCode.ShouldBeEquivalentTo(HttpStatusCode.OK);
        }

        [Fact]
        public async Task Update_WhenCityNotExist_ShouldReturnNullWithOkStatusCode()
        {
            await _context.Database.EnsureDeletedAsync();

            var response = await _httpClient.PutAsync(RequestUris.GetDeleteUpdateCityUri, SerializeObjectToHttpContent(CityEntities.CityEntity));

            response.StatusCode.ShouldBeEquivalentTo(HttpStatusCode.InternalServerError);
        }

        [Fact]
        public async Task Update_WhenCityExist_ShouldReturnUpdatedCityWithOkStatusCode()
        {
            await _context.Database.EnsureDeletedAsync();

            _context.Cities.Add(CityEntities.CityEntity);
            await _context.SaveChangesAsync();
            var cityToUpdate = CityEntities.CityEntity;
            cityToUpdate.Population = 200_000;

            var response = await _httpClient.PutAsync(RequestUris.GetDeleteUpdateCityUri, SerializeObjectToHttpContent(cityToUpdate));

            response.StatusCode.ShouldBeEquivalentTo(HttpStatusCode.OK);
            var result = await response.Content.ReadAsAsync<CityEntity>();
            result.Population.ShouldBe(cityToUpdate.Population);
        }
    }
}
