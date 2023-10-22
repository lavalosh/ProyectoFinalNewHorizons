namespace Muchik.Market.Infrastructure.CrossCutting.Jwt;

public interface IJwtManager
{
    string GenerateToken(string userId, string username);
}
