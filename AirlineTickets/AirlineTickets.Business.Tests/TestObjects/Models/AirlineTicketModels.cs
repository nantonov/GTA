namespace AirlineTickets.Business.Tests.TestObjects.Models
{
    internal class AirlineTicketModels
    {
        public static AirlineTicket TicketModel = new()
        {
            Id = 1,
            DepartureTime = DateTime.Now,
            ArrivalTime = DateTime.Now,
            Price = 400,
            PassengerCredentials = "Passenger"
        };

        public static List<AirlineTicket> TicketModelsList = new()
        {
            new AirlineTicket()
            {
                Id = 1,
                DepartureTime = DateTime.Now,
                ArrivalTime = DateTime.Now,
                Price = 400,
                PassengerCredentials = "Passenger 1"
            },

            new AirlineTicket()
            {
                Id = 2,
                DepartureTime = DateTime.Now,
                ArrivalTime = DateTime.Now,
                Price = 500,
                PassengerCredentials = "Passenger 2"
            },

            new AirlineTicket()
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
