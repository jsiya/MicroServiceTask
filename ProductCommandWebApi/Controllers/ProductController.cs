using Microsoft.AspNetCore.Mvc;
using ProductCommandWebApi.Models;
using ProductCommandWebApi.Repositories.Abstracts;
using ProductCommandWebApi.ViewModels;

namespace ProductCommandWebApi.Controllers;

public class ProductController: ControllerBase
{
    private ICommandRepository<Product> _productRepository;

    public ProductController(ICommandRepository<Product> prductRepository)
    {
        _productRepository = prductRepository;
    }
    [HttpPost("AddProduct")]
    public async Task<OkObjectResult> AddProduct([FromBody] Product product)
    {
        await _productRepository.AddAsync(product);
        await _productRepository.SaveChangesAsync();
        return Ok("Product Added!!!");
    }

    [HttpDelete("DeleteProduct")]
    public async Task<IActionResult> DeleteProduct(int id)
    {
        _productRepository.Delete(id);
        await _productRepository.SaveChangesAsync();
        return Ok("Deleted!");
    }

    [HttpPut("UpdateProduct")]
    public async Task<IActionResult> UpdateProduct(int id, [FromBody] ProductVM productVm)
    {
        var prod = new Product()
        {
            Id = id,
            Name = productVm.Name,
            Description = productVm.Desc
        };
        
        _productRepository.Update(prod);
        await _productRepository.SaveChangesAsync();
        return Ok("Updated!");
    }
}