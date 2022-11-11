namespace AirlineTickets.API.Tests.Tests
{
    public class HotelControllerTests : APITestsBase
    {
        [Fact]
        public async Task GetAll_WhenHotelsExist_ShouldReturnHotelsWithOkStatusCode()
        {
            await _context.Database.EnsureDeletedAsync();

            _context.Cities.AddRange(CityEntities.CityEntitiesList);
            _context.Hotels.AddRange(HotelEntities.HotelEntitiesList);
            await _context.SaveChangesAsync();

            var response = await _httpClient.GetAsync(RequestUris.DefaultHotelUri);

            response.StatusCode.ShouldBeEquivalentTo(HttpStatusCode.OK);
            var result = await response.Content.ReadAsAsync<List<HotelEntity>>();
            result.ShouldNotBeEmpty();
        }

        [Fact]
        public async Task GetById_WhenHotelNotExist_ShouldNotReturnHotelWithNoContentStatusCode()
        {
            await _context.Database.EnsureDeletedAsync();

            var response = await _httpClient.GetAsync(RequestUris.GetDeleteUpdateHotelUri);

            response.StatusCode.ShouldBeEquivalentTo(HttpStatusCode.NoContent);
            var result = await response.Content.ReadAsAsync<HotelEntity>();
            result.ShouldBeNull();
        }

        [Fact]
        public async Task GetById_WhenHotelExist_ShouldReturnHotelWithOkStatusCode()
        {
            await _context.Database.EnsureDeletedAsync();

            _context.Cities.Add(CityEntities.CityEntity);
            _context.Hotels.Add(HotelEntities.HotelEntity);
            await _context.SaveChangesAsync();

            var response = await _httpClient.GetAsync(RequestUris.GetDeleteUpdateHotelUri);

            response.StatusCode.ShouldBeEquivalentTo(HttpStatusCode.OK);
            var result = await response.Content.ReadAsAsync<HotelEntity>();
            result.Name.ShouldBe(HotelEntities.HotelEntity.Name);
            result.RoomsNumber.ShouldBe(HotelEntities.HotelEntity.RoomsNumber);
        }

        [Fact]
        public async Task Create_WhenHotelViewModelIsSet_ShouldReturnCorrectHotelWithOkStatusCode()
        {
            await _context.Database.EnsureDeletedAsync();

            var response = await _httpClient.PostAsync(RequestUris.DefaultHotelUri,
                SerializeObjectToHttpContent(HotelEntities.HotelEntity));

            response.StatusCode.ShouldBeEquivalentTo(HttpStatusCode.OK);
            var result = await response.Content.ReadAsAsync<HotelEntity>();
            result.ShouldNotBeNull();
        }

        [Fact]
        public async Task Delete_WhenHotelNotExist_ShouldReturnNullWithOkStatusCode()
        {
            await _context.Database.EnsureDeletedAsync();

            var response = await _httpClient.DeleteAsync(RequestUris.GetDeleteUpdateHotelUri);

            response.StatusCode.ShouldBeEquivalentTo(HttpStatusCode.OK);
            var result = await response.Content.ReadAsAsync<HotelEntity>();
            result.ShouldBeNull();
        }

        [Fact]
        public async Task Delete_WhenIdIsSet_ShouldReturnOkStatusCode()
        {
            await _context.Database.EnsureDeletedAsync();

            _context.Cities.Add(CityEntities.CityEntity);
            _context.Hotels.Add(HotelEntities.HotelEntity);
            await _context.SaveChangesAsync();

            var response = await _httpClient.DeleteAsync(RequestUris.GetDeleteUpdateHotelUri);

            response.StatusCode.ShouldBeEquivalentTo(HttpStatusCode.OK);
        }

        [Fact]
        public async Task Update_WhenHotelNotExist_ShouldReturnNullWithOkStatusCode()
        {
            await _context.Database.EnsureDeletedAsync();

            var response = await _httpClient.PutAsync(RequestUris.GetDeleteUpdateHotelUri, SerializeObjectToHttpContent(HotelEntities.HotelEntity));

            response.StatusCode.ShouldBeEquivalentTo(HttpStatusCode.InternalServerError);
        }

        [Fact]
        public async Task Update_WhenHotelExist_ShouldReturnUpdatedHotelWithOkStatusCode()
        {
            await _context.Database.EnsureDeletedAsync();

            _context.Hotels.Add(HotelEntities.HotelEntity);
            await _context.SaveChangesAsync();
            var hotelToUpdate = HotelEntities.HotelEntity;
            hotelToUpdate.RoomsNumber = 25;

            var response = await _httpClient.PutAsync(RequestUris.GetDeleteUpdateHotelUri, SerializeObjectToHttpContent(hotelToUpdate));

            response.StatusCode.ShouldBeEquivalentTo(HttpStatusCode.OK);
            var result = await response.Content.ReadAsAsync<HotelEntity>();
            result.RoomsNumber.ShouldBe(hotelToUpdate.RoomsNumber);
        }
    }
}
