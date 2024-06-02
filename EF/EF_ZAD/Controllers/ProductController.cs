using EF_ZAD.Controllers.Requests;
using EF_ZAD.Services;
using EF_ZAD.Validators;
using FluentValidation;
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
    public async Task<IActionResult> CreateProduct(ProductRequest productRequest,
        IValidator<ProductRequest> validator)
    {
        var validationResult = await validator.ValidateAsync(productRequest);
        if (!validationResult.IsValid)
            return BadRequest(validationResult.Errors);
    
        return Ok(await _productService.CreateProduct(productRequest));
    }
}