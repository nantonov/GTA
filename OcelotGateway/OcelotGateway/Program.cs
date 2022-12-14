using Ocelot.Cache.CacheManager;
using Ocelot.DependencyInjection;
using Ocelot.Middleware;

var builder = WebApplication.CreateBuilder(args);

var ocelotConfig = new ConfigurationBuilder().AddJsonFile("ocelot.json").Build();

builder.Services.AddOcelot(ocelotConfig)
    .AddCacheManager(x =>
    {
        x.WithDictionaryHandle();
    }); ;

var app = builder.Build();

app.MapGet("/", () => "Ocelot API Gateway");
await app.UseOcelot();
app.Run();
