using chatbot.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace chatbot.Application.Interfaces
{
    public interface IHRISService
    {
        Task<LeaveBalanceDTO> GetLeaveBalanceAsync(Guid employeeId);
        Task<IEnumerable<LeaveRequestDTO>> GetLeaveRequestsAsync(Guid employeeId);
        Task<IEnumerable<AttendanceDTO>> GetAttendanceAsync(Guid employeeId, DateTime from, DateTime to);
        Task<IEnumerable<TeamLeaveStatusDTO>> GetTeamLeaveStatusAsync(Guid managerId);
        Task<IEnumerable<PendingApprovalDTO>> GetPendingApprovalsAsync(Guid managerId);
    }
}