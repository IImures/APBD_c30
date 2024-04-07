using Microsoft.AspNetCore.Mvc;
using REST_API_CWICZNIA_4.Type.Controller.Request;
using REST_API_CWICZNIA_4.Type.Service;

namespace REST_API_CWICZNIA_4.Type.Controller;

[ApiController]
[Route("api/types")]
public class TypeController : ControllerBase
{
    private TypeService _typeService;
    
    public TypeController(TypeService typeService)
    {
        _typeService = typeService;
    }
    
    [HttpGet]
    public IActionResult GetTypes()
    {
        return Ok(_typeService.GetAll());
    }
    
    [HttpGet("{id}")]
    public IActionResult GetType(int id)
    {
        return Ok(_typeService.GetById(id));
    }
    
    [HttpPut]
    public IActionResult CreateType(TypeRequest typeRequest)
    {
        return StatusCode(204,  _typeService.CreateType(typeRequest));
    }
    
    [HttpPatch("{id}")]
    public IActionResult UpdateType(int id, TypeRequest typeRequest)
    {
        return StatusCode(204, _typeService.UpdateType(id, typeRequest));
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteType(int id)
    {
        _typeService.DeleteType(id);
        return NoContent();
    }
    
    
}