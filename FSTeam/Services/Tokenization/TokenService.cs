using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using FSTeam.Model.Internal;
using Microsoft.Extensions.Configuration.UserSecrets;
using Microsoft.IdentityModel.Tokens;
using JwtRegisteredClaimNames = Microsoft.IdentityModel.JsonWebTokens.JwtRegisteredClaimNames;

namespace FSTeam.Services.Tokenization;

public class TokenService : ITokenService
{
    private readonly IConfiguration _configuration;
    
    public TokenService(IConfiguration configuration)
    {
        _configuration = configuration;
        if (string.IsNullOrEmpty(_configuration["JWT:Secret"]))
        {
            throw new ArgumentNullException(paramName: "JWT:Secret",
            "JWT secret key is not configured in appsettings.json");
        }
    }

    public string GenerateAccessToken(Users users)
    {
        var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"]!));
        var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

        var claims = new[]
        {
            new Claim(JwtRegisteredClaimNames.Sub, users.Id.ToString()),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            new Claim(ClaimTypes.Name, users.Credentials.UserName),
            new Claim(ClaimTypes.Role, users.Information.Level.ToString())
        };

        var token = new JwtSecurityToken(
            issuer: _configuration["JWT:Secret"],
        audience: _configuration["JWT:audience"],
        claims: claims,
        notBefore: DateTime.UtcNow.AddMinutes(_configuration.GetValue<int>("JWT:TokenValidityInMinutes")),
        signingCredentials: credentials
            );

        return new JwtSecurityTokenHandler().WriteToken(token);
    }

    public string GenerateRefreshToken(Users users)
    {
        var randomNumber = new byte[64];
        using var rng = RandomNumberGenerator.Create();
        rng.GetBytes(randomNumber);
        return Convert.ToBase64String(randomNumber);
    }

    public ClaimsPrincipal? GetPrincipalFromExpiredToken(string token)
    {
        throw new NotImplementedException();
    }
}