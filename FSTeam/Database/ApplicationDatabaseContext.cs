using FSTeam.Jwt;
using FSTeam.Model.Internal;
using FSTeam.Models;
using FSTeam.Models.Internal;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace FSTeam.Database;

public class ApplicationDatabaseContext : IdentityDbContext<Jwtidentity>
{
    public ApplicationDatabaseContext(DbContextOptions<ApplicationDatabaseContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }
    //model registration 
    public DbSet<Testmodel> Testmodels { get; set; }
    
        public DbSet<Users> Users { get; set; }
        public DbSet<UsersCredentials> usersCredentials { get; set; }
        public DbSet<UsersInformation> usersInformation { get; set; }
}





