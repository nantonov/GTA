using AirlineTickets.BLL.Models;

namespace AirlineTickets.BLL.Tests.TestObjects.Models
{
    internal static class HotelModels
    {
        public static Hotel HotelModel = new()
        {
            Id = 1,
            Name = "Simple hotel",
            StarsNumber = 3,
            RoomsNumber = 15
        };

        public static List<Hotel> HotelModelsList = new()
        {
            new Hotel()
            {
                Id = 1,
                Name = "First hotel",
                StarsNumber = 3,
                RoomsNumber = 15
            },

            new Hotel()
            {
                Id = 2,
                Name = "Second hotel",
                StarsNumber = 4,
                RoomsNumber = 25
            },

            new Hotel()
            {
                Id = 3,
                Name = "Third hotel",
                StarsNumber = 5,
                RoomsNumber = 50
            }
        };
    }
}
