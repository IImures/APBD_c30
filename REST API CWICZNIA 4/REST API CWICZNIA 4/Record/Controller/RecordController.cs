
using Microsoft.AspNetCore.Mvc;
using REST_API_CWICZNIA_4.Record.Controller.Request;
using REST_API_CWICZNIA_4.Record.Service;

namespace REST_API_CWICZNIA_4.Record.Controller;

[ApiController]
[Route("api/records")]
public class RecordController : ControllerBase
{
    private RecordService _recordService;
    
    public RecordController(RecordService recordService)
    {
        _recordService = recordService;
    }
    
    [HttpGet]
    public IActionResult GetRecords()
    {
        return Ok(_recordService.GetAll());
    }
    
    [HttpGet("{id}")]
    public IActionResult GetRecord(int id)
    {
        return Ok(_recordService.GetById(id));
    }
    
    [HttpPut]
    public IActionResult CreateRecord(RecordRequest recordRequest)
    {
        _recordService.CreateRecord(recordRequest);
        return Ok();
    }
    
    [HttpPatch("{id}")]
    public IActionResult UpdateRecord(int id, RecordRequest recordRequest)
    {
        return Ok(_recordService.UpdateRecord(id, recordRequest));
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteRecord(int id)
    {
        _recordService.DeleteRecord(id);
        return NoContent();
    }
}