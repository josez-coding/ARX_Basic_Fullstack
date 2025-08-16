using Microsoft.AspNetCore.Identity;

namespace FSTeam.Jwt;

public class Jwtidentity : IdentityUser
{
    public string? RefreshToken { get; set; }
    public DateTime RefreshTokenExpiry { get; set; }
}