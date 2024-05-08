using KolokwiumPrep.Group.Service;
using Microsoft.AspNetCore.Mvc;

namespace KolokwiumPrep.Group.Controller;

[ApiController]
[Route("api/groups")]
public class GroupController : ControllerBase
{

    private readonly IGroupService _groupService;
    
    public GroupController(IGroupService groupService)
    {
        _groupService = groupService;
    }
    
    [HttpGet("{id}")]
    public async Task<IActionResult> getGroupById(int id)
    {
        GroupEntity.GroupEntity group = await _groupService.GetGroupById(id);
        if (group == null)
        {
            return NotFound();
        }
        return Ok(group);
    }
}