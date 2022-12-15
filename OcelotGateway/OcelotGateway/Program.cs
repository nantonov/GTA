using Ocelot.Cache.CacheManager;
using Ocelot.DependencyInjection;
using Ocelot.Middleware;
using Ocelot.Values;

var builder = WebApplication.CreateBuilder(args);

var ocelotConfig = new ConfigurationBuilder().AddJsonFile("ocelot.json").Build();
var mainConfig = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
var identityServerUrl = mainConfig["Urls:IdentityServer"];

builder.Services.AddOcelot(ocelotConfig)
    .AddCacheManager(config =>
    {
        config.WithDictionaryHandle();
    }); ;

builder.Services.AddAuthentication()
    .AddJwtBearer("Identity", config =>
    {
        config.Authority = identityServerUrl;
        config.RequireHttpsMetadata = false;
        config.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters()
        {
            ValidateAudience = false,
            ValidateIssuer = true,
            ValidIssuer = identityServerUrl
        };
    });

builder.Services.AddCors(config =>
{
    config.AddPolicy("DefaultPolicy",
        builder =>
        {
            builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
        });
});

builder.Services.AddMvcCore(options => options.EnableEndpointRouting = false).AddApiExplorer();

builder.Services.AddSwaggerForOcelot(ocelotConfig);

var app = builder.Build();

app.UseSwaggerForOcelotUI(opt =>
{
    opt.PathToSwaggerGenerator = "/swagger/docs";
});

app.UseAuthentication();

app.UseCors("DefaultPolicy");

app.UseMvc();

app.MapGet("/", () => "Ocelot API Gateway");
await app.UseOcelot();
app.Run();
