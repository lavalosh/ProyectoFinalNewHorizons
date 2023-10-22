using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Muchik.Market.Security.Domain.Interfaces;
using Muchik.Market.Security.Infrastructure.Context;
using Muchik.Market.Security.Infrastructure.Repositories;

namespace Muchik.Market.Security.Infrastructure;

public static class DependencyContainer
{
    public static IServiceCollection AddInfrastructureSecurity(this IServiceCollection services, IConfiguration configuration)
    {
        string connectionString = configuration.GetValue("connectionStrings:securityConnection", "Not Found");
        services.AddTransient<IUserRepository, UserRepository>();
        services.AddDbContext<SecurityContext>(opt =>
        {
            opt.UseSqlServer(connectionString);
        });
        return services;
    }
}
