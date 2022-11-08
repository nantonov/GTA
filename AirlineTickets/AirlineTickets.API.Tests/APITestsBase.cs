using AirlineTickets.DAL.Context;
using Microsoft.AspNetCore.Authorization.Policy;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Net.Mime;

namespace AirlineTickets.API.Tests
{
    public class APITestsBase : IDisposable
    {
        protected readonly HttpClient _httpClient;
        protected readonly WebApplicationFactory<Program> _appFactory;
        protected ApplicationDbContext _context;

        protected APITestsBase()
        {
            _appFactory = new WebApplicationFactory<Program>().WithWebHostBuilder(builder =>
                builder.ConfigureServices(services =>
                {
                    var dbContextDescriptor = services.SingleOrDefault(x =>
                        x.ServiceType == typeof(DbContextOptions<ApplicationDbContext>));

                    services.Remove(dbContextDescriptor);

                    services.AddDbContext<ApplicationDbContext>(options => options.UseInMemoryDatabase("TestDb"));
                    services.AddSingleton<IPolicyEvaluator, FakeAuthEvaluator>();
                }));

            _httpClient = _appFactory.CreateClient();
            _context = _appFactory.Services.CreateScope().ServiceProvider.GetService<ApplicationDbContext>();
        }

        public void Dispose()
        {
            _context.Dispose();

            GC.SuppressFinalize(this);
        }
    }
}
