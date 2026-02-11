using chatbot.Application.Interfaces;
using chatbot.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace chatbot.Api.Controllers;

[ApiController]
[Route("api/rolepermissions")]
public class RolePermissionController : ControllerBase
{
    private readonly IRolePermissionService _service;

    public RolePermissionController(IRolePermissionService service)
    {
        _service = service;
    }

    [HttpGet]
    public IActionResult Get()
    {
        return Ok(_service.GetAll());
    }

    [HttpGet("{roleId}/{permissionId}")]
    public async Task<IActionResult> GetById(Guid roleId, Guid permissionId)
    {
        var rolePermission = await _service.GetByIdAsync(roleId, permissionId);
        if (rolePermission == null)
        {
            return NotFound();
        }
        return Ok(rolePermission);
    }

    [HttpPost]
    public async Task<IActionResult> Create(RolePermission rolePermission)
    {
        await _service.AddAsync(rolePermission);
        return Ok();
    }

    [HttpDelete("{roleId}/{permissionId}")]
    public async Task<IActionResult> Delete(Guid roleId, Guid permissionId)
    {
        await _service.DeleteAsync(roleId, permissionId);
        return Ok();
    }
}
