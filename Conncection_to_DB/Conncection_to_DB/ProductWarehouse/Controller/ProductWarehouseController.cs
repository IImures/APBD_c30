using Conncection_to_DB.ProductWarehouse.Controller.Request;
using Conncection_to_DB.ProductWarehouse.Service;
using Microsoft.AspNetCore.Mvc;

namespace Conncection_to_DB.ProductWarehouse.Controller;


[ApiController]
[Route("api/p_warehouses")]
public class ProductWarehouseController : ControllerBase
{
    private readonly IProductWarehouseService _productWarehouseService;
    
    public ProductWarehouseController(IProductWarehouseService productWarehouseService)
    {
        _productWarehouseService = productWarehouseService;
    }
    
    [HttpPut]
    public IActionResult CreateProduct(ProductWarehouseRequest productWarehouseRequest)
    {
        _productWarehouseService.CreateProduct(productWarehouseRequest);
        return Created();
    }
}