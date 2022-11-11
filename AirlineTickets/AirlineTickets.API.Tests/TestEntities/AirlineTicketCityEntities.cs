using AirlineTickets.Core.Enums;
using AirlineTickets.DAL.Entities;

namespace AirlineTickets.API.Tests.TestEntities
{
    internal static class AirlineTicketCityEntities
    {
        public static AirlineTicketCityEntity TicketCityEntity = new()
        {
            AirlineTicketId = 1,
            CityId = 1,
            StayingStatus = CityStayingStatus.Arrival
        };

        public static List<AirlineTicketCityEntity> TicketCityEntitiesList = new()
        {
            new AirlineTicketCityEntity()
            {
                AirlineTicketId = 1,
                CityId = 1,
                StayingStatus = CityStayingStatus.Arrival
            },

            new AirlineTicketCityEntity()
            {
                AirlineTicketId = 2,
                CityId = 2,
                StayingStatus = CityStayingStatus.Departure
            },

            new AirlineTicketCityEntity()
            {
                AirlineTicketId = 3,
                CityId = 3,
                StayingStatus = CityStayingStatus.Transit
            }
        };
    }
}
