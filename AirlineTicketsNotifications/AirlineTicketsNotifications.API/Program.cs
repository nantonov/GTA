using AirlineTicketsNotifications.API.Mapper.Profiles;
using AirlineTicketsNotifications.API.Validation.Validators;
using AirlineTicketsNotifications.API.ViewModels.NotificationRequest;
using AirlineTicketsNotifications.API.ViewModels.TicketInfo;
using AirlineTicketsNotifications.BLL.DI;
using FluentValidation;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var configurationBuilder = builder.Configuration;

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddBLLLogicDependencies(configurationBuilder);

builder.Services.AddScoped<IValidator<CreateNotificationRequestViewModel>, NotificationRequestValidator>()
    .AddScoped<IValidator<NewTicketInfoViewModel>, TicketInfoValidator>();

builder.Services.AddAutoMapper(typeof(ModelViewModel));

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
