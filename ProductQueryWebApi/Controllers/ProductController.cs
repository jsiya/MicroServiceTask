using Microsoft.AspNetCore.Mvc;
using ProductQueryWebApi.Migrations;
using ProductQueryWebApi.Repositories.Abstracts;

namespace ProductQueryWebApi.Controllers;

public class ProductController: ControllerBase
{
    private readonly IQueryRepository<Product> _productRepository;

    public ProductController(IQueryRepository<Product> productRepository)
    {
        _productRepository = productRepository;
    }
    
    [HttpGet("GetAllProducts")]
    public async Task<IActionResult> GetAllProducts()
    {
        var res = await _productRepository.GetAllAsync();
        return Ok(res);
    }
}