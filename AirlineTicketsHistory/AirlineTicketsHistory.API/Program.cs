using AirlineTicketsHistory.API.Mapper.Profiles;
using AirlineTicketsHistory.API.Middleware;
using AirlineTicketsHistory.API.Validation.Validators;
using AirlineTicketsHistory.API.ViewModels.AirlineTicket;
using AirlineTicketsHistory.BLL.DI;
using FluentValidation;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var configurationBuilder = builder.Configuration;

builder.Services.AddCors(config =>
{
    config.AddPolicy("DefaultPolicy",
        builder =>
        {
            builder.WithOrigins("http://localhost/3000").AllowAnyMethod().AllowAnyHeader();
        });
});

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddBLLLogicDependencies(configurationBuilder);

builder.Services.AddScoped<IValidator<CreateAirlineTicketViewModel>, AirlineTicketValidator>();

builder.Services.AddAutoMapper(typeof(ModelViewModel));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddleware<ExceptionMiddleware>();

app.UseHttpsRedirection();

app.UseCors("DefaultPolicy");

app.MapControllers();

app.Run();
