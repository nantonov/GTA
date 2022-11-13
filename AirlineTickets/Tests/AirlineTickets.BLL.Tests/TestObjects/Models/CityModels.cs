using AirlineTickets.BLL.Models;

namespace AirlineTickets.BLL.Tests.TestObjects.Models
{
    internal class CityModels
    {
        public static City CityModel = new()
        {
            Id = 1,
            Name = "Simple city",
            Population = 100_000,
            Area = 50
        };

        public static List<City> CityModelsList = new()
        {
            new City()
            {
                Id = 1,
                Name = "First city",
                Population = 100_000,
                Area = 50
            },

            new City()
            {
                Id = 2,
                Name = "Second city",
                Population = 1_000_000,
                Area = 350
            },

            new City()
            {
                Id = 3,
                Name = "Third city",
                Population = 200_000,
                Area = 120
            }
        };
    }
}
