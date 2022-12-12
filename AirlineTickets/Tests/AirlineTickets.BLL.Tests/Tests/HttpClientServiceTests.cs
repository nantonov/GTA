namespace AirlineTickets.BLL.Tests.Tests
{
    public class HttpClientServiceTests
    {
        private readonly Mock<IHttpClientFactory> _httpClientFactory;
        private readonly IHttpClientService _httpClientService;

        public HttpClientServiceTests()
        {
            _httpClientFactory = new Mock<IHttpClientFactory>();
            _httpClientService = new HttpClientService(_httpClientFactory.Object);
        }

        [Fact]
        public async Task GetAuthNotificationsClientAsync_WhenMethodIsInvoked_ShouldReturnClient()
        {
            _httpClientFactory.Setup(f => f.CreateClient(string.Empty)).Returns(new HttpClient());

            var result = await _httpClientService.GetAuthNotificationsClientAsync(default);

            result.ShouldBeAssignableTo(typeof(HttpClient));
        }
    }
}
