using AirlineTickets.DAL.Entities;

namespace AirlineTickets.BLL.Tests.TestObjects.Entities
{
    internal static class HotelEntities
    {
        public static HotelEntity HotelEntity = new()
        {
            Id = 1,
            Name = "Simple hotel",
            StarsNumber = 3,
            RoomsNumber = 15
        };

        public static List<HotelEntity> HotelEntitiesList = new()
        {
            new HotelEntity()
            {
                Id = 1,
                Name = "First hotel",
                StarsNumber = 3,
                RoomsNumber = 15
            },

            new HotelEntity()
            {
                Id = 2,
                Name = "Second hotel",
                StarsNumber = 4,
                RoomsNumber = 25
            },

            new HotelEntity()
            {
                Id = 3,
                Name = "Third hotel",
                StarsNumber = 5,
                RoomsNumber = 50
            }
        };
    }
}
