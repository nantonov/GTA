namespace AirlineTicketsHistory.API.Tests.Tests
{
    public class UserTicketsHistoryControllerTests : APITestsBase
    {
        [Fact]
        public async Task GetAll_WhenHistoriesExist_ShouldReturnHistoriesWithOkStatusCodeAsync()
        {
            await _userTicketsCollection.InsertManyAsync(UserTicketHistoryEntities.HistoryEntitiesList);

            var response = await _httpClient.GetAsync(RequestUris.DefaultHistoryUri);
            var result = await response.Content.ReadAsStringAsync();

            response.StatusCode.ShouldBeEquivalentTo(HttpStatusCode.OK);
            result.ShouldNotBeEmpty();
        }

        [Fact]
        public async Task GetByUserId_WhenHistoryExist_ShouldReturnHistoryWithOkStatusCode()
        {
            await _userTicketsCollection.InsertOneAsync(UserTicketHistoryEntities.HistoryEntity);

            var response = await _httpClient.GetAsync(RequestUris.GetDeleteHistoryUri);
            var result = await response.Content.ReadAsStringAsync();

            response.StatusCode.ShouldBeEquivalentTo(HttpStatusCode.OK);
            result.ShouldNotBeEmpty();
        }

        [Fact]
        public async Task Delete_WhenIdIsSet_ShouldReturnOkStatusCode()
        {
            await _userTicketsCollection.InsertOneAsync(UserTicketHistoryEntities.HistoryEntity);

            var response = await _httpClient.DeleteAsync(RequestUris.GetDeleteHistoryUri);
            var result = await response.Content.ReadAsStringAsync();

            response.StatusCode.ShouldBeEquivalentTo(HttpStatusCode.OK);
        }

        [Fact]
        public async Task AddTicketToUserHistory_WhenHistoryViewModelIsSet_ShouldReturnUpdatedHistoryWithOkStatusCode()
        {
            var response = await _httpClient.PostAsync(RequestUris.DefaultTicketUri,
                SerializeObjectToHttpContent(AirlineTicketEntities.TicketEntity));
            var result = await response.Content.ReadAsStringAsync();

            response.StatusCode.ShouldBeEquivalentTo(HttpStatusCode.OK);
            result.ShouldNotBeNull();
        }

        [Fact]
        public async Task RemoveTicketFromUserHistory_WhenIdsAreSet_ShouldReturnUpdatedHistoryWithOkStatusCode()
        {
            await _userTicketsCollection.InsertOneAsync(UserTicketHistoryEntities.HistoryEntityWithTicket);

            var response = await _httpClient.DeleteAsync(RequestUris.DeleteTicketUri);
            var result = await response.Content.ReadAsStringAsync();

            response.StatusCode.ShouldBeEquivalentTo(HttpStatusCode.OK);
            result.ShouldNotBeNull();
        }
    }
}