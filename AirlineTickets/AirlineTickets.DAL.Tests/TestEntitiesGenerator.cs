using AirlineTickets.DAL.Entities;

namespace AirlineTickets.DAL.Tests
{
    public static class TestEntitiesGenerator
    {
        private static Fixture _fixtureBuilder = new();

        public static AirlineTicketEntity GetAirlineTicketEntity() => _fixtureBuilder.Build<AirlineTicketEntity>()
            .Without(t => t.AirlineTicketCities).Create();

        public static IEnumerable<AirlineTicketEntity> GetAirlineTicketEntityList() =>
            _fixtureBuilder.Build<AirlineTicketEntity>().Without(t => t.AirlineTicketCities).CreateMany(3);

        public static CityEntity GetCityEntity() => _fixtureBuilder.Build<CityEntity>().Without(c => c.Hotels)
                .Without(c => c.AirlineTicketCities).Create();

        public static IEnumerable<CityEntity> GetCityEntityList() => _fixtureBuilder.Build<CityEntity>().Without(c => c.Hotels)
                .Without(c => c.AirlineTicketCities).CreateMany(3);

        public static AirlineTicketCityEntity GetAirlineTicketCityEntityWithoutCitiesAndTickets() =>
            _fixtureBuilder.Build<AirlineTicketCityEntity>().Without(tc => tc.City).Without(tc => tc.AirlineTicket).Create();

        public static HotelEntity GetHotelEntityWithoutCity() => _fixtureBuilder.Build<HotelEntity>().Without(h => h.City).Create();

        public static AirlineTicketCityEntity GetAirlineTicketCityEntity()
        {
            var initialTicketCity = _fixtureBuilder.Build<AirlineTicketCityEntity>().Without(tc => tc.City)
                .Without(tc => tc.AirlineTicket).Create();
            var initialCity = _fixtureBuilder.Build<CityEntity>().Without(c => c.AirlineTicketCities)
                .Without(c => c.Hotels).Create();
            var initialTicket = _fixtureBuilder.Build<AirlineTicketEntity>().Without(t => t.AirlineTicketCities).Create();
            initialTicketCity.City = initialCity;
            initialTicketCity.AirlineTicket = initialTicket;

            return initialTicketCity;
        }

        public static IEnumerable<AirlineTicketCityEntity> GetAirlineTicketCityEntityList()
        {
            var initialTicketCityList = _fixtureBuilder.Build<AirlineTicketCityEntity>().Without(tc => tc.City)
                .Without(tc => tc.AirlineTicket).CreateMany(3).ToList();
            var initialCityList = _fixtureBuilder.Build<CityEntity>().Without(c => c.AirlineTicketCities)
                .Without(c => c.Hotels).CreateMany(3).ToList();
            var initialTicketList = _fixtureBuilder.Build<AirlineTicketEntity>().Without(t => t.AirlineTicketCities)
                .CreateMany(3).ToList();

            for (int i = 0; i < initialTicketCityList.Count(); i++)
            {
                initialTicketCityList[i].City = initialCityList[i];
                initialTicketCityList[i].AirlineTicket = initialTicketList[i];
            }

            return initialTicketCityList;
        }

        public static HotelEntity GetHotelEntity()
        {
            var initialHotel = _fixtureBuilder.Build<HotelEntity>().Without(h => h.City).Create();
            var initialCity = _fixtureBuilder.Build<CityEntity>().Without(c => c.AirlineTicketCities)
                .Without(c => c.Hotels).Create();
            initialHotel.City = initialCity;

            return initialHotel;
        }

        public static IEnumerable<HotelEntity> GetHotelEntityList()
        {
            var initialHotelList = _fixtureBuilder.Build<HotelEntity>().Without(h => h.City).CreateMany(3).ToList();
            var initialCityList = _fixtureBuilder.Build<CityEntity>().Without(c => c.AirlineTicketCities)
                .Without(c => c.Hotels).CreateMany(3).ToList();

            for (int i = 0; i < initialHotelList.Count(); i++)
            {
                initialHotelList[i].City = initialCityList[i];
            }

            return initialHotelList;
        }
    }
}
