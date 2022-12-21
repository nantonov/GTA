using AirlineTickets.DAL.External.Interfaces;
using MassTransit;
using Messages;

namespace AirlineTickets.DAL.External.Services
{
    public class ExternalService : IExternalService
    {
        private readonly IPublishEndpoint _publishEndpoint;

        public ExternalService(IPublishEndpoint publishEndpoint)
        {
            _publishEndpoint = publishEndpoint;
        }

        public async Task PublishNewTicketInfo(NewTicketInfoMessage ticketInfo, CancellationToken cancellationToken) =>
            await _publishEndpoint.Publish(ticketInfo, cancellationToken);
    }
}
