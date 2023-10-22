﻿using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.Data;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Muchik.Market.Infrastructure.CrossCutting.Jwt;

public class JwtManager : IJwtManager
{
    private readonly IConfiguration _configuration;
    public JwtManager(IConfiguration configuration)
    {
        _configuration = configuration;
    }
    public string GenerateToken(string userId, string username)
    {
        var issuer = _configuration["jwtSettings:issuer"];
        var audience = _configuration["jwtSettings:audience"];
        int lifetime = int.Parse(_configuration["jwtSettings:lifetime"]!.ToString());
        var secretKey = _configuration["jwtSettings:secretKey"] ?? "";

        var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));
        var signingCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);
        var header = new JwtHeader(signingCredentials);

        var claims = new[]
        {
                new Claim(ClaimTypes.Sid, userId),
                new Claim(ClaimTypes.Email, username)
            };

        var payload = new JwtPayload(issuer, audience, claims, DateTime.UtcNow, DateTime.UtcNow.AddSeconds(lifetime));
        var token = new JwtSecurityToken(header, payload);

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}
