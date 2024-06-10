namespace ProductQueryWebApi.Repositories.Abstracts;

public interface IQueryRepository<T> where T: class
{
    Task<IEnumerable<T>> GetAllAsync();
    Task<T?> GetByIdAsync(int id);
}