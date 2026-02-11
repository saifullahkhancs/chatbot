using chatbot.Application.Interfaces;
using chatbot.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace chatbot.Api.Controllers;

[ApiController]
[Route("api/userroles")]
public class UserRoleController : ControllerBase
{
    private readonly IUserRoleService _service;

    public UserRoleController(IUserRoleService service)
    {
        _service = service;
    }

    [HttpGet]
    public IActionResult Get()
    {
        return Ok(_service.GetAll());
    }

    [HttpGet("{userId}/{roleId}")]
    public async Task<IActionResult> GetById(Guid userId, Guid roleId)
    {
        var userRole = await _service.GetByIdAsync(userId, roleId);
        if (userRole == null)
        {
            return NotFound();
        }
        return Ok(userRole);
    }

    [HttpPost]
    public async Task<IActionResult> Create(UserRole userRole)
    {
        await _service.AddAsync(userRole);
        return Ok();
    }

    [HttpDelete("{userId}/{roleId}")]
    public async Task<IActionResult> Delete(Guid userId, Guid roleId)
    {
        await _service.DeleteAsync(userId, roleId);
        return Ok();
    }
}
