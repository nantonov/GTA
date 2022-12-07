namespace AirlineTickets.BLL.Interfaces
{
    public interface IHttpClientService
    {
        public Task<HttpClient> GetAuthNotificationsClientAsync(CancellationToken cancellationToken);
    }
}
