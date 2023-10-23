using Muchik.Market.Invoice.Application.Interfaces;
using Muchik.Market.Invoice.Application.Services;
using Muchik.Market.Invoice.Infrastructure.Context;
using Muchik.Market.Invoice.Infrastructure;
using Muchik.Market.Invoice.Application.Mapping;
using Steeltoe.Extensions.Configuration.ConfigServer;

var builder = WebApplication.CreateBuilder(args);

builder.AddConfigServer();
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddAutoMapper(typeof(DtoToEntityProfile));

//Services
builder.Services.AddTransient<IInvoiceService, InvoiceService>();

//Repositories
builder.Services.AddInfrastructureInvoices(builder.Configuration);

////Cross-Cutting
//builder.Services.AddTransient<IJwtManager, JwtManager>();

//Context
builder.Services.AddTransient<InvoicesContext>();

var app = builder.Build();


// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
app.UseSwagger();
app.UseSwaggerUI();
//}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
