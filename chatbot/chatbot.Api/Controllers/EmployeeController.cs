using chatbot.Application.DTOs;
using chatbot.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace chatbot.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class EmployeeController : ControllerBase
    {
        private readonly IHRISService _hrisService;

        public EmployeeController(IHRISService hrisService)
        {
            _hrisService = hrisService;
        }

        [HttpGet("leave-balance")]
        public async Task<IActionResult> GetLeaveBalance()
        {
            var employeeId = Guid.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value);
            var balance = await _hrisService.GetLeaveBalanceAsync(employeeId);
            return Ok(balance);
        }

        [HttpGet("leave-requests")]
        public async Task<IActionResult> GetLeaveRequests()
        {
            var employeeId = Guid.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value);
            var requests = await _hrisService.GetLeaveRequestsAsync(employeeId);
            return Ok(requests);
        }

        [HttpGet("attendance")]
        public async Task<IActionResult> GetAttendance([FromQuery] DateTime from, [FromQuery] DateTime to)
        {
            var employeeId = Guid.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value);
            var attendance = await _hrisService.GetAttendanceAsync(employeeId, from, to);
            return Ok(attendance);
        }
    }
}