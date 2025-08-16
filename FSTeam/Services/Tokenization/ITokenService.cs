using System.Security.Claims;
using FSTeam.Model.Internal;

namespace FSTeam.Services.Tokenization;

public interface ITokenService
{
    string GenerateAccessToken(Users users);
    string GenerateRefreshToken(Users users);
    ClaimsPrincipal? GetPrincipalFromExpiredToken(string token);
}