using Microsoft.EntityFrameworkCore;
using ProductCommandWebApi.Models;

namespace ProductCommandWebApi.Contexts;

public class AppDbContext:DbContext
{
   public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
   {
      
   }

   public virtual DbSet<Product> Products { get; set; }
    
}