using EF_ZAD.Controllers.Requests;
using EF_ZAD.Services;
using Microsoft.AspNetCore.Mvc;

namespace EF_ZAD.Controllers;

[ApiController]
[Route("api/products")]
public class ProductController :ControllerBase
{
    private readonly IProductService _productService;
    
    public ProductController(IProductService productService)
    {
        _productService = productService;
    }
 
    [HttpPost]
    public async Task<IActionResult> CreateProduct(ProductRequest productRequest)
    {
        return Ok(await _productService.CreateProduct(productRequest));
    }
}