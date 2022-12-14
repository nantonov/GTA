namespace AirlineTickets.BLL.Tests.TestObjects.Entities
{
    internal static class AirlineTicketEntities
    {
        public static AirlineTicketEntity TicketEntity = new()
        {
            Id = 1,
            DepartureTime = DateTime.Now,
            ArrivalTime = DateTime.Now,
            Price = 400,
            PassengerCredentials = "Passenger"
        };

        public static List<AirlineTicketEntity> TicketEntitiesList = new()
        {
            new AirlineTicketEntity()
            {
                Id = 1,
                DepartureTime = DateTime.Now,
                ArrivalTime = DateTime.Now,
                Price = 400,
                PassengerCredentials = "Passenger 1"
            },

            new AirlineTicketEntity()
            {
                Id = 2,
                DepartureTime = DateTime.Now,
                ArrivalTime = DateTime.Now,
                Price = 500,
                PassengerCredentials = "Passenger 2"
            },

            new AirlineTicketEntity()
            {
                Id = 3,
                DepartureTime = DateTime.Now,
                ArrivalTime = DateTime.Now,
                Price = 800,
                PassengerCredentials = "Passenger 3"
            }
        };
    }
}
