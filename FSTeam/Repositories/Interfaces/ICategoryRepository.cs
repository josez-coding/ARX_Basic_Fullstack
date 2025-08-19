using FSTeam.Models;

namespace FSTeam.Repositories;

public interface ICategoryRepository
{
    Task<IEnumerable<Category>> GetAllAsync();
    Task<Category> AddAsync(Category category);
}