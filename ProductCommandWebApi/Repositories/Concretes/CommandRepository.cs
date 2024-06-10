using ProductCommandWebApi.Contexts;
using ProductCommandWebApi.Models;
using ProductCommandWebApi.Repositories.Abstracts;

namespace ProductCommandWebApi.Repositories.Concretes;

public class CommandRepository: ICommandRepository<Product>
{
    private AppDbContext _context;

    public CommandRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task AddAsync(Product entity)
    {
        await _context.Products.AddAsync(entity);
    }

    public void Update(Product entity)
    {
        _context.Products.Update(entity);
    }

    public void Delete(int id)
    {
        var entity = _context.Products.FirstOrDefault(x => x.Id == id);
        _context.Products.Remove(entity!);
    }

    public async Task SaveChangesAsync()
    {
        await _context.SaveChangesAsync();
    }
}