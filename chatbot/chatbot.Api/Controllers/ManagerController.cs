using chatbot.Application.DTOs;
using chatbot.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace chatbot.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Manager")]
    public class ManagerController : ControllerBase
    {
        private readonly IHRISService _hrisService;

        public ManagerController(IHRISService hrisService)
        {
            _hrisService = hrisService;
        }

        [HttpGet("team-leave")]
        public async Task<IActionResult> GetTeamLeaveStatus()
        {
            var managerId = Guid.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value);
            var teamLeave = await _hrisService.GetTeamLeaveStatusAsync(managerId);
            return Ok(teamLeave);
        }

        [HttpGet("pending-approvals")]
        public async Task<IActionResult> GetPendingApprovals()
        {
            var managerId = Guid.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value);
            var approvals = await _hrisService.GetPendingApprovalsAsync(managerId);
            return Ok(approvals);
        }
    }
}