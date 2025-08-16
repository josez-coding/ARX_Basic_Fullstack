using FSTeam.Commands.Handler;
using FSTeam.Database;
using FSTeam.Models;
using FSTeam.Repositories;
using FSTeam.Repositories.TestRepository;
using FSTeam.Services;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

namespace FSTeam.Config;

public class ServiceRegistration
{
    public void OnLoad(IServiceCollection services, IConfiguration configuration)
    {
        AddLocalDatabase(services, configuration);
        ServiceOnLoad(services);
        SwaggerOnLoad(services);
    }

    private void AddLocalDatabase(IServiceCollection services, IConfiguration configuration)
    {
        var localserver = Environment.GetEnvironmentVariable("LOCAL_SERVER");
        var localUserid = Environment.GetEnvironmentVariable("USER_ID");
        
        if (string.IsNullOrEmpty(localserver)  || string.IsNullOrEmpty(localUserid))
        {
            throw new InvalidOperationException("LOCAL_SERVER or USERID is empty");
        }
        var connectionString = configuration["connectionStrings:local_db"]
            .Replace("{LOCAL_SERVER}", localserver)
            .Replace("{USER_ID}", localUserid);
        services.AddDbContext<ApplicationDatabaseContext>(options =>
        options.UseSqlServer(connectionString,
                provider => provider.EnableRetryOnFailure())
            .LogTo(Console.WriteLine, LogLevel.Information));
    }
    private void ServiceOnLoad(IServiceCollection services)
    {
        services.AddControllers();
        services.AddEndpointsApiExplorer();
        services.AddScoped(typeof(IRepository<Testmodel>), typeof(TestRepositoryData));
        services.AddScoped<ITokenService, TokenService>();
        services.AddScoped<TestDataCommandHandler>();
        services.AddMediatR(typeof(Program).Assembly);
    }
    public void SwaggerOnLoad(IServiceCollection services)
    {
        services.AddSwaggerGen(c =>
        {
            c.AddSecurityDefinition("ApiKey", new OpenApiSecurityScheme
            {
                Description = "The API key to access API",
                Type = SecuritySchemeType.ApiKey,
                Name = "x-api-key",
                In = ParameterLocation.Header,
                Scheme = "ApiKey"
            });
            var scheme = new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "ApiKey",
                },
                In = ParameterLocation.Header
            };
        var requirement = new OpenApiSecurityRequirement
        {
            { scheme, new List<string>() }
        };
        c.AddSecurityRequirement(requirement);
    });
    }
}
        


        