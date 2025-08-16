namespace FSTeam.Repositories;

public interface IRepository<T> where T : class
{
        Task<IEnumerable<T>> GetAllSync();
        Task<string> AddNewName(string name);
        

}