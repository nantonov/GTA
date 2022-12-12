namespace AirlineTicketsNotifications.API.Tests.Tests
{
    public class NotificationControllerTests : APITestsBase
    {
        [Fact]
        public async Task CreateNotificationRequest_WhenRequestViewModelIsSet_ShouldReturnCorrectRequestWithOkStatusCode()
        {
            await _context.Database.EnsureDeletedAsync();

            var response = await _httpClient.PostAsync(RequestUris.NotificationRequestUri,
                SerializeObjectToHttpContent(NotificationRequestEntities.RequestEntity));
            var result = await response.Content.ReadAsAsync<NotificationRequestEntity>();

            response.StatusCode.ShouldBeEquivalentTo(HttpStatusCode.OK);
            result.ShouldNotBeNull();
        }
    }
}