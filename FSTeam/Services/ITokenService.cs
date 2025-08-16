using System.Security.Claims;
using FSTeam.Models;

namespace FSTeam.Services;

public interface ITokenService
{
    Task<List<Testmodel>> GetAllDataFromTestModel();
    Task<string> AddNewName(string name);
    ClaimsPrincipal? GetClaimsPrincipal(string token);
}