using Muchik.Market.Pay.Application.interfaces;
using Muchik.Market.Pay.Application.services;
using Muchik.Market.Pay.Domain.interfaces;
using Muchik.Market.Pay.Infrastructure.context;
using Muchik.Market.Pay.Infrastructure.repositories;
using Microsoft.EntityFrameworkCore;
using Muchik.Market.Pay.Application.mappings;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//AutoMapper
builder.Services.AddAutoMapper(typeof(EntityToDtoProfile), typeof(DtoToEntityProfile));

//SQL Server
builder.Services.AddDbContext<PaymentContext>(config =>
{
    config.UseMySQL(builder.Configuration.GetValue<string>("connectionStrings:MuchikConnection"));
});

//RabbitMQ Settings
//builder.Services.Configure<RabbitMqSettings>(builder.Configuration.GetSection("rabbitMqSettings"));


//Services
builder.Services.AddTransient<IPaymentService, PaymentService>();
//Repositories
builder.Services.AddTransient<IPaymentRepository, PaymentRepository>();
//Context
builder.Services.AddTransient<PaymentContext>();


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
