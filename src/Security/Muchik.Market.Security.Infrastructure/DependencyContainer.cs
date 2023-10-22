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
        services.AddTransient<IUserRepository, UserRepository>();
        services.AddDbContext<SecurityContext>(opt =>
        {
            opt.UseSqlServer(configuration.GetConnectionString("securityConnection"));
        });
        return services;
    }
}
