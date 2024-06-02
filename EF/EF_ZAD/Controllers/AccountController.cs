using EF_ZAD.Services;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace EF_ZAD.Controllers;

[ApiController]
[Route("api/accounts")]
public class AccountController : ControllerBase
{
    private readonly IAccountService _accountService;
    
    public AccountController(IAccountService accountService)
    {
        _accountService = accountService;
    }
    
    [HttpGet("{id}")]
    public async Task<IActionResult> GetAccounts(int id)
    {
        return Ok(await _accountService.getAccountById(id));
    }
}