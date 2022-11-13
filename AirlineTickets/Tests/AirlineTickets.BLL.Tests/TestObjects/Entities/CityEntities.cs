namespace AirlineTickets.BLL.Tests.TestObjects.Entities
{
    internal static class CityEntities
    {
        public static CityEntity CityEntity = new()
        {
            Id = 1,
            Name = "Simple city",
            Population = 100_000,
            Area = 50
        };

        public static List<CityEntity> CityEntitiesList = new()
        {
            new CityEntity()
            {
                Id = 1,
                Name = "First city",
                Population = 100_000,
                Area = 50
            },

            new CityEntity()
            {
                Id = 2,
                Name = "Second city",
                Population = 1_000_000,
                Area = 350
            },

            new CityEntity()
            {
                Id = 3,
                Name = "Third city",
                Population = 200_000,
                Area = 120
            }
        };
    }
}
