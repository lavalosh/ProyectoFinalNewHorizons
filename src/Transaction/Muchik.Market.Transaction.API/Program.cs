using Muchik.Market.Infrastructure.repositories;
using Muchik.Market.Transaction.Application.interfaces;
using Muchik.Market.Transaction.Application.services;
using Muchik.Market.Transaction.Domain.interfaces;
using Muchik.Market.Transaction.Infrastructure.context;
using Muchik.Market.Transaction.Application.mappings;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


//AutoMapper
builder.Services.AddAutoMapper(typeof(EntityToDtoProfile), typeof(DtoToEntityProfile));

//SQL Server
builder.Services.AddDbContext<TransactionContext>(config =>
{
    //config.UseMySQL(builder.Configuration.GetValue<string>("connectionStrings:MuchikConnection"));
});

//RabbitMQ Settings
//builder.Services.Configure<RabbitMqSettings>(builder.Configuration.GetSection("rabbitMqSettings"));


//Services
builder.Services.AddTransient<ITransactionService, TransactionService>();
//Repositories
builder.Services.AddTransient<ITransactionRepository, TransactionRepository>();
//Context
builder.Services.AddTransient<TransactionContext>();



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
