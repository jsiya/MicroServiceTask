namespace ProductCommandWebApi.Repositories.Abstracts;

public interface ICommandRepository<T> where T: class
{
    Task AddAsync(T entity);
    void Update(T entity);
    void Delete(int id);
    Task SaveChangesAsync();
}