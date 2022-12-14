namespace AirlineTicketsNotifications.DAL.Tests
{
    public class DataTestsHelpers
    {
        protected ApplicationDbContext _context = new ApplicationDbContext
            (new DbContextOptionsBuilder().UseInMemoryDatabase(Guid.NewGuid().ToString()).Options);

        protected Fixture _fixtureBuilder = new Fixture();
    }
}
