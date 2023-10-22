namespace Muchik.Market.Security.Infrastructure.CrossCutting.Jwt;

public interface IJwtManager
{
    string GenerateToken(string userId, string username);
}
