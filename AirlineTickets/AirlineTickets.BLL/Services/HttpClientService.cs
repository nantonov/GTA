using AirlineTickets.BLL.Interfaces;
using AirlineTickets.Core.Constants;
using IdentityModel.Client;

namespace AirlineTickets.BLL.Services
{
    public class HttpClientService : IHttpClientService
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public HttpClientService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<HttpClient> GetAuthNotificationsClientAsync(CancellationToken cancellationToken)
        {
            var authClient = _httpClientFactory.CreateClient();
            var discoveryDocument = await authClient.GetDiscoveryDocumentAsync("https://localhost:5001", cancellationToken);

            var tokenResponse = await authClient.RequestClientCredentialsTokenAsync(
                new ClientCredentialsTokenRequest
                {
                    Address = discoveryDocument.TokenEndpoint,
                    ClientId = AuthValues.TicketsClientId,
                    ClientSecret = AuthValues.TicketsClientSecret,
                    Scope = AuthValues.NotificationsScopeName
                }, cancellationToken);

            var notificationsClient = _httpClientFactory.CreateClient();

            notificationsClient.SetBearerToken(tokenResponse.AccessToken);

            return authClient;
        }
    }
}
