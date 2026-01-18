using chatbot.Application.Interfaces;
using chatbot.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace chatbot.Api.Controllers;

[ApiController]
[Route("api/users")]
public class UsersController : ControllerBase
{
    private readonly IUserService _service;

    public UsersController(IUserService service)
    {
        _service = service;
    }

    [HttpGet]
    public IActionResult Get()
    {
        return Ok(_service.GetAll());
    }

    [HttpPost]
    public async Task<IActionResult> Create(User user)
    {
        await _service.AddAsync(user);
        return Ok();
    }

    [HttpPut]
    public async Task<IActionResult> Update(User user)
    {
        await _service.UpdateAsync(user);
        return Ok();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        await _service.DeleteAsync(id);
        return Ok();
    }
}
