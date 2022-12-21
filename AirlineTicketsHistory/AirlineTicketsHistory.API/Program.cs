using AirlineTicketsHistory.API.Extensions;
using AirlineTicketsHistory.API.Mapper.Profiles;
using AirlineTicketsHistory.API.Middleware;
using AirlineTicketsHistory.API.Validation.Validators;
using AirlineTicketsHistory.API.ViewModels.AirlineTicket;
using AirlineTicketsHistory.BLL.DI;
using FluentValidation;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Swashbuckle.AspNetCore.SwaggerUI;

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

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
{
    options.Authority = configurationBuilder["Urls:Authority"];
    options.RequireHttpsMetadata = false;
    options.Audience = "AirlineTicketsHistoryAPI";
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        ValidateIssuer = false,
        ValidateAudience = false
    };
});
builder.Services.AddAuthorization();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerDependencies(configurationBuilder);

builder.Services.AddBLLLogicDependencies(configurationBuilder);

builder.Services.AddScoped<IValidator<CreateAirlineTicketViewModel>, AirlineTicketValidator>();

builder.Services.AddAutoMapper(typeof(ModelViewModel));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "AirlineTicketsHistory API");
        options.DocumentTitle = "Title";
        options.RoutePrefix = "docs";
        options.DocExpansion(DocExpansion.List);
        options.OAuthClientId("client_id_history");
        options.OAuthScopeSeparator(" ");
        options.OAuthClientSecret("client_secret_history");
    });
}

app.UseMiddleware<ExceptionMiddleware>();

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.UseCors("DefaultPolicy");

app.MapControllers();

app.Run();

public partial class Program { }