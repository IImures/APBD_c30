using KolokwiumPrep.Student.Service;
using Microsoft.AspNetCore.Mvc;

namespace KolokwiumPrep.Student.Controller;

[ApiController]
[Route("api/students")]
public class StudentController : ControllerBase
{
    private readonly IStudentService _studentService;
    
    public StudentController(IStudentService studentService)
    {
        _studentService = studentService;
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetStudents(int id)
    {
        return Ok(await _studentService.getStudentById(id));
    }


    [HttpDelete]
    public async Task<IActionResult> DeleteStudent(int id)
    {
        if(!await _studentService.DeleteStudent(id))
        {
            return NotFound();
        }
        return NoContent();
    }
}