namespace AirlineTickets.BLL.Interfaces
{
    public interface IHttpClientService
    {
        Task<HttpClient> GetAuthNotificationsClientAsync(CancellationToken cancellationToken);
    }
}
