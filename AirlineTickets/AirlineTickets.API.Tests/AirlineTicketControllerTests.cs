using AirlineTickets.DAL.Entities;
using System.Net;

namespace AirlineTickets.API.Tests
{
    public class AirlineTicketControllerTests : APITestsBase
    {
        [Fact]
        public async Task GetAll_WhenTicketsExist_ShouldReturnTicketsWithOkStatusCodeAsync()
        {
            await _context.Database.EnsureDeletedAsync();

            await _context.AirlineTickets.AddRangeAsync(AirlineTicketEntities.TicketEntitiesList);
            await _context.SaveChangesAsync();

            var response = await _httpClient.GetAsync("/AirlineTicket/GetAll");

            response.StatusCode.ShouldBeEquivalentTo(HttpStatusCode.OK);
            response.Content.ReadAsAsync<List<AirlineTicketEntity>>().Result.ShouldNotBeEmpty();
        }
    }
}