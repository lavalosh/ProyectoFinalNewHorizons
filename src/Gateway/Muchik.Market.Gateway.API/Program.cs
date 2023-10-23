using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.IdentityModel.Tokens;
using Ocelot.DependencyInjection;
using Ocelot.Middleware;
using Ocelot.Provider.Polly;
using Steeltoe.Discovery.Client;
using Steeltoe.Extensions.Configuration.ConfigServer;
using System.Text;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.


//Stelltoe Config Server
builder.AddConfigServer();

// Add services to the container.

//Ocelot
builder.Configuration.AddJsonFile("ocelot.json", optional: false, reloadOnChange: true);
builder.Services.AddOcelot().AddPolly();

//Consul
builder.Services.AddDiscoveryClient();

var issuer = builder.Configuration["jwtSettings:issuer"];
var audience = builder.Configuration["jwtSettings:audience"];
var secretKey = builder.Configuration["jwtSettings:secretKey"];

builder.Services
    .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(opt =>
    {
        opt.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = issuer,
            ValidAudience = audience,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey))
        };
    }
);

var app = builder.Build();


app.UseHttpsRedirection();

app.UseAuthorization();

app.UseMiddleware<AuthorizationMiddleware>();

app.UseOcelot().Wait();

app.MapControllers();

app.Run();
