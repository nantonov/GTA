using Microsoft.AspNetCore.Authorization.Policy;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Net.Mime;
using System.Text;
using AirlineTicketsHistory.DAL.Context;
using AirlineTicketsHistory.DAL.Interfaces;
using MongoDB.Driver;

namespace AirlineTicketsHistory.API.Tests
{
    public class APITestsBase
    {
        protected readonly HttpClient _httpClient;
        private readonly WebApplicationFactory<Program> _appFactory;
        protected IMongoCollection<UserTicketsHistoryEntity> _userTicketsCollection;
        private readonly IConfiguration _configuration;

        public APITestsBase()
        {
            Dictionary<string, string> myConfiguration = new()
                    {
                        {"ConnectionStrings:Mongo", "mongodb://localhost:27017"},
                        {"Mongo:TicketsHistoryDbName", "TestAirlineTickets"},
                        {"Mongo:TicketsHistoryCollectionName", "TestUserAirlineTickets"}
                    };

            var config = new ConfigurationBuilder().AddInMemoryCollection(myConfiguration).Build();

            _appFactory = new WebApplicationFactory<Program>().WithWebHostBuilder(builder =>
                builder.ConfigureServices(services =>
                {
                    var dbContextDescriptor = services.SingleOrDefault(x =>
                        x.ServiceType == typeof(IMongoDbContext));

                    if (dbContextDescriptor is not null)
                    {
                        services.Remove(dbContextDescriptor);
                    }

                    services.AddSingleton<IMongoDbContext>(_ => new MongoDbContext(config));
                    services.AddSingleton<IPolicyEvaluator, FakeAuthEvaluator>();
                }));

            _httpClient = _appFactory.CreateClient();

            var services = _appFactory.Services.CreateScope().ServiceProvider;

            _configuration = services.GetService<IConfiguration>();
            _userTicketsCollection = services.GetService<IMongoDbContext>().UserTicketsCollection;

            _httpClient.DefaultRequestHeaders.Authorization = new("Bearer",
                Convert.ToBase64String(Encoding.ASCII.GetBytes(_configuration["Jwt:Key"] ?? "key")));
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
    }
}
