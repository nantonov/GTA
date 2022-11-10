using AirlineTickets.DAL.Entities;

namespace AirlineTickets.API.Tests.TestEntities
{
    internal static class HotelEntities
    {
        public static HotelEntity HotelEntity = new()
        {
            Id = 1,
            Name = "Simple hotel",
            StarsNumber = 3,
            RoomsNumber = 15,
            CityId = 1
        };

        public static List<HotelEntity> HotelEntitiesList = new()
        {
            new HotelEntity()
            {
                Id = 1,
                Name = "First hotel",
                StarsNumber = 3,
                RoomsNumber = 15, 
                CityId = 1
            },

            new HotelEntity()
            {
                Id = 2,
                Name = "Second hotel",
                StarsNumber = 4,
                RoomsNumber = 25,
                CityId = 2
            },

            new HotelEntity()
            {
                Id = 3,
                Name = "Third hotel",
                StarsNumber = 5,
                RoomsNumber = 50,
                CityId = 3
            }
        };
    }
}
