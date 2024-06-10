using Microsoft.EntityFrameworkCore;
using ProductQueryWebApi.Contexts;
using ProductQueryWebApi.Migrations;
using ProductQueryWebApi.Repositories.Abstracts;

namespace ProductQueryWebApi.Repositories.Concretes;

public class QueryRepository: IQueryRepository<Product>
{
    private AppDbContext _context;

    public QueryRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Product>> GetAllAsync()
    {
        return _context.Products;
    }

    public async Task<Product?> GetByIdAsync(int id)
    {
        return  await _context.Products.FirstOrDefaultAsync(x => x.Id == id);
    }
}