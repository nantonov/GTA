using IdentityServer;
using IdentityServer.Data;
using IdentityServer.Models;
using IdentityServer4;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Facebook;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Security.Claims;

var seed = args.Contains("/seed");
if (seed)
{
    args = args.Except(new[] { "/seed" }).ToArray();
}

var builder = WebApplication.CreateBuilder(args);

var configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();

builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddDefaultTokenProviders();

var identityBuilder = builder.Services.AddIdentityServer(options =>
{
    options.Events.RaiseErrorEvents = true;
    options.Events.RaiseInformationEvents = true;
    options.Events.RaiseFailureEvents = true;
    options.Events.RaiseSuccessEvents = true;

    // see https://identityserver4.readthedocs.io/en/latest/topics/resources.html
    options.EmitStaticAudienceClaim = true;
})
    .AddInMemoryIdentityResources(Config.IdentityResources)
    .AddInMemoryApiScopes(Config.ApiScopes)
    .AddInMemoryClients(Config.Clients)
    .AddAspNetIdentity<ApplicationUser>();

// not recommended for production - you need to store your key material somewhere secure
identityBuilder.AddDeveloperSigningCredential();

builder.Services.AddAuthentication()
    .AddFacebook(options =>
    {
        options.SignInScheme = IdentityServerConstants.ExternalCookieAuthenticationScheme;
        options.AppId = configuration["Authentication:Facebook:AppId"];
        options.AppSecret = configuration["Authentication:Facebook:AppSecret"]; 
        options.SaveTokens = true;
        options.CallbackPath = new PathString("/signin-facebook-token");
        options.ClaimActions.MapJsonKey(ClaimTypes.NameIdentifier, "user_id");
        options.ClaimActions.MapJsonKey("email", "email");
    });

/*options.SignInScheme = IdentityServerConstants.ExternalCookieAuthenticationScheme;
        options.ClientId = builder.Configuration["Authentication:VK:ClientId"];
        options.ClientSecret = builder.Configuration["Authentication:VK:ClientSecret"];
        options.ClaimsIssuer = "VK Provider";
        options.SaveTokens = true;
        options.CallbackPath = new PathString("/signin-vkontakte-token");
        options.AuthorizationEndpoint = "https://oauth.vk.com/authorize";
        options.TokenEndpoint = "https://oauth.vk.com/access_token";
        options.Scope.Add("email");
        options.ClaimActions.MapJsonKey(ClaimTypes.NameIdentifier, "user_id");
        options.ClaimActions.MapJsonKey("email", "email");

        options.Events = new OAuthEvents
        {
            OnCreatingTicket = context =>
            {
                context.RunClaimActions(context.TokenResponse.Response.RootElement);
                return Task.CompletedTask;
            },
            OnRemoteFailure = OnFailure
        };
    });

Task OnFailure(RemoteFailureContext arg)
{
    Console.WriteLine(arg);
    return Task.CompletedTask;
}*/

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.UseStaticFiles();

app.UseRouting();
app.UseIdentityServer();
app.UseAuthorization();
app.UseEndpoints(endpoints =>
{
    endpoints.MapDefaultControllerRoute();
});

app.Run();