namespace AirlineTicketsHistory.API.Tests.TestEntities
{
    internal static class AirlineTicketEntities
    {
        public static CreateAirlineTicketViewModel TicketEntity = new()
        {
            UserId = "user",
            TicketId = 1,
            PassengerCredentials = "Passenger"
        };
    }
}
