using AirlineTickets.API.Extensions;
using AirlineTickets.API.Mapper.Profiles;
using AirlineTickets.API.Middleware;
using AirlineTickets.API.Validation.Validators;
using AirlineTickets.API.ViewModels.AirlineTicket;
using AirlineTickets.API.ViewModels.AirlineTicketCity;
using AirlineTickets.API.ViewModels.City;
using AirlineTickets.API.ViewModels.Hotel;
using AirlineTickets.BLL.DI;
using FluentValidation;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Swashbuckle.AspNetCore.SwaggerUI;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var configurationBuilder = builder.Configuration;

builder.Services.AddHttpClient();

builder.Services.AddCors(config =>
{
    config.AddPolicy("DefaultPolicy",
        builder =>
        {
            builder.WithOrigins("http://localhost/3000").AllowAnyMethod().AllowAnyHeader();
        });
});

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
{
    options.Authority = configurationBuilder["Urls:Authority"];
    options.RequireHttpsMetadata = false;
    options.Audience = "AirlineTicketsAPI";
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(builder.Configuration["Jwt:Key"])),
        ValidateIssuer = false,
        ValidateAudience = false
    };
});
builder.Services.AddAuthorization();

builder.Services.AddControllersWithViews()
    .AddNewtonsoftJson(options =>
    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
);
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerDependencies(configurationBuilder);

builder.Services.AddBLLLogicDependencies(configurationBuilder);

builder.Services.AddScoped<IValidator<CreateUpdateTicketCityViewModel>, AirlineTicketCityValidator>()
    .AddScoped<IValidator<CreateUpdateTicketViewModel>, AirlineTicketValidator>()
    .AddScoped<IValidator<CreateUpdateCityViewModel>, CityValidator>()
    .AddScoped<IValidator<CreateUpdateHotelViewModel>, HotelValidator>();

builder.Services.AddAutoMapper(typeof(ModelViewModel));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "AirlineTickets API");
        options.DocumentTitle = "Title";
        options.RoutePrefix = "docs";
        options.DocExpansion(DocExpansion.List);
        options.OAuthClientId("client_id_swagger");
        options.OAuthScopeSeparator(" ");
        options.OAuthClientSecret("client_secret_swagger");
    });
}

app.UseMiddleware<ExceptionMiddleware>();

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.UseCors("DefaultPolicy");

app.MapControllers();

app.Run();