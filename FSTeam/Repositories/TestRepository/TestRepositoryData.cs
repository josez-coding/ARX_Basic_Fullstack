using FSTeam.Database;
using FSTeam.Models;
using Microsoft.EntityFrameworkCore;

namespace FSTeam.Repositories.TestRepository;

public class TestRepositoryData : IRepository<Testmodel>
{
    private readonly ApplicationDatabaseContext _context;

    public TestRepositoryData(ApplicationDatabaseContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Testmodel>> GetAllSync()
    {

        return await _context.Testmodels.ToListAsync();
    }

    public async Task<string> AddNewName(string newName)
    {
        if (string.IsNullOrEmpty(newName))
        {
            return "Name is empty";

            
        }
        var testModel = new Testmodel
        {
            Id = Guid.NewGuid(),
            Name = newName

        };

        await _context.Testmodels.AddAsync(testModel);
        await _context.SaveChangesAsync();
        return "Success";
    }
}
    