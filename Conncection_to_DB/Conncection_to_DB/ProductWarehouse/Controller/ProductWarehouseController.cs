using System.Transactions;
using Conncection_to_DB.Exceptions;
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
    public async Task<IActionResult> CreateProduct(ProductWarehouseRequest productWarehouseRequest)
    {
        try
        {
            await _productWarehouseService.CreateProduct(productWarehouseRequest);
        }
        catch (NotFound e)
        {
            return NotFound(e.Message);
        }
        catch (WrongValue e)
        {
            return BadRequest(e.Message);
        }
        catch (TransactionAbortedException e)
        {
            return  StatusCode(500);
        }

        return Created();
    }
}