using AirlineTickets.Core.Enums;

namespace AirlineTickets.Business.Tests.TestObjects.Models
{
    internal class AirlineTicketCityModels
    {
        public static AirlineTicketCity TicketCityModel = new()
        {
            AirlineTicketId = 1,
            CityId = 1,
            StayingStatus = CityStayingStatus.Arrival
        };

        public static List<AirlineTicketCity> TicketCityModelsList = new()
        {
            new AirlineTicketCity()
            {
                AirlineTicketId = 1,
                CityId = 1,
                StayingStatus = CityStayingStatus.Arrival
            },

            new AirlineTicketCity()
            {
                AirlineTicketId = 2,
                CityId = 2,
                StayingStatus = CityStayingStatus.Departure
            },

            new AirlineTicketCity()
            {
                AirlineTicketId = 3,
                CityId = 3,
                StayingStatus = CityStayingStatus.Transit
            }
        };
    }
}
