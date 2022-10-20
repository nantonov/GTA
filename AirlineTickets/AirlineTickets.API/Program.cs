using AirlineTickets.API.Mapper.Profiles;
using AirlineTickets.API.Validation.Validators;
using AirlineTickets.API.ViewModels.AirlineTicket;
using AirlineTickets.API.ViewModels.AirlineTicketCity;
using AirlineTickets.API.ViewModels.City;
using AirlineTickets.API.ViewModels.Hotel;
using AirlineTickets.Business.DI;
using AutoMapper;
using FluentValidation;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllersWithViews()
    .AddNewtonsoftJson(options =>
    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
);
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var configurationBuilder = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();

builder.Services.AddBusinessLogicDependencies(configurationBuilder);

builder.Services.AddScoped<IValidator<CreateUpdateTicketCityViewModel>, AirlineTicketCityValidator>()
    .AddScoped<IValidator<CreateUpdateTicketViewModel>, AirlineTicketValidator>()
    .AddScoped<IValidator<CreateUpdateCityViewModel>, CityValidator>()
    .AddScoped<IValidator<CreateUpdateHotelViewModel>, HotelValidator>();

var mapperConfig = new MapperConfiguration(mc =>
{
    mc.AddProfile(new EntityModel());
    mc.AddProfile(new ModelViewModel());
});

IMapper mapper = mapperConfig.CreateMapper();
builder.Services.AddSingleton(mapper);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
