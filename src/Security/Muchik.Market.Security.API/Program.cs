using Muchik.Market.Security.Application.Interfaces;
using Muchik.Market.Security.Application.Mapping;
using Muchik.Market.Security.Application.Services;
using Muchik.Market.Security.Infrastructure;
using Muchik.Market.Security.Infrastructure.Context;
using Muchik.Market.Security.Infrastructure.CrossCutting.Jwt;

var builder = WebApplication.CreateBuilder(args);
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAutoMapper(typeof(DtoToEntityProfile));

//Services
builder.Services.AddTransient<ISecurityService, SecurityService>();

//Repositories
builder.Services.AddInfrastructureSecurity(builder.Configuration);

//Cross-Cutting
builder.Services.AddTransient<IJwtManager, JwtManager>();

//Context
builder.Services.AddTransient<SecurityContext>();

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
