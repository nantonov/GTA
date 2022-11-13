using AirlineTickets.DAL.Context;
using Microsoft.AspNetCore.Authorization.Policy;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Net.Mime;
using System.Text;

namespace AirlineTickets.API.Tests
{
    public class APITestsBase : IDisposable
    {
        protected readonly HttpClient _httpClient;
        private readonly WebApplicationFactory<Program> _appFactory;
        protected readonly ApplicationDbContext _context;
        private readonly IConfiguration _configuration;

        public APITestsBase()
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

            var services = _appFactory.Services.CreateScope().ServiceProvider;

            _configuration = services.GetService<IConfiguration>();
            _context = services.GetService<ApplicationDbContext>();

            _httpClient.DefaultRequestHeaders.Authorization = new("Bearer",
                Convert.ToBase64String(Encoding.ASCII.GetBytes(_configuration["Jwt:Key"])));
        }

        protected static HttpContent SerializeObjectToHttpContent(object objectToParse)
        {
            string jsonString = JsonConvert.SerializeObject(objectToParse, Formatting.None, new JsonSerializerSettings()
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            });

            ByteArrayContent content = new StringContent(jsonString);

            content.Headers.ContentType = new MediaTypeHeaderValue(MediaTypeNames.Application.Json);

            return content;
        }

        public void Dispose()
        {
            _context.Dispose();

            GC.SuppressFinalize(this);
        }
    }
}
