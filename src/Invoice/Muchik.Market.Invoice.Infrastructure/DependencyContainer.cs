using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Muchik.Market.Invoice.Domain.Interfaces;
using Muchik.Market.Invoice.Infrastructure.Context;
using Muchik.Market.Invoice.Infrastructure.Repositories;

namespace Muchik.Market.Invoice.Infrastructure;

public static class DependencyContainer
{
    public static IServiceCollection AddInfrastructureInvoices(this IServiceCollection services, IConfiguration configuration)
    {
        string connectionString = configuration.GetValue("connectionStrings:invoiceConnection", "Not Found");
        services.AddTransient<IInvoiceRepository, InvoiceRepository>();
        services.AddDbContext<InvoicesContext>(opt =>
        {
            opt.UseNpgsql(connectionString);
        });
        return services;
    }
}
