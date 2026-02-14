using chatbot.Application.DTOs;
using chatbot.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace chatbot.Application.Services
{
    public class HRISService : IHRISService
    {
        public Task<LeaveBalanceDTO> GetLeaveBalanceAsync(Guid employeeId)
        {
            // Dummy data
            return Task.FromResult(new LeaveBalanceDTO
            {
                AnnualLeave = 24,
                SickLeave = 12,
                CasualLeave = 5,
                UsedAnnual = 5,
                UsedSick = 2,
                UsedCasual = 1
            });
        }

        public Task<IEnumerable<LeaveRequestDTO>> GetLeaveRequestsAsync(Guid employeeId)
        {
            // Dummy data
            var requests = new List<LeaveRequestDTO>
            {
                new() {
                    Id = Guid.NewGuid(),
                    LeaveType = "Annual",
                    FromDate = DateTime.Now.AddDays(10),
                    ToDate = DateTime.Now.AddDays(15),
                    Status = "Pending",
                    Days = 5
                },
                new() {
                    Id = Guid.NewGuid(),
                    LeaveType = "Sick",
                    FromDate = DateTime.Now.AddDays(-5),
                    ToDate = DateTime.Now.AddDays(-3),
                    Status = "Approved",
                    Days = 3
                }
            };

            return Task.FromResult(requests.AsEnumerable());
        }

        public Task<IEnumerable<AttendanceDTO>> GetAttendanceAsync(Guid employeeId, DateTime from, DateTime to)
        {
            // Dummy data
            var attendance = new List<AttendanceDTO>
            {
                new() {
                    Date = DateTime.Now.AddDays(-1),
                    CheckIn = DateTime.Now.AddDays(-1).Date.AddHours(9),
                    CheckOut = DateTime.Now.AddDays(-1).Date.AddHours(18),
                    Status = "Present"
                },
                new() {
                    Date = DateTime.Now.AddDays(-2),
                    CheckIn = DateTime.Now.AddDays(-2).Date.AddHours(9),
                    CheckOut = DateTime.Now.AddDays(-2).Date.AddHours(18),
                    Status = "Present"
                }
            };

            return Task.FromResult(attendance.AsEnumerable());
        }

        public Task<IEnumerable<TeamLeaveStatusDTO>> GetTeamLeaveStatusAsync(Guid managerId)
        {
            // Dummy data
            var teamLeave = new List<TeamLeaveStatusDTO>
            {
                new() {
                    EmployeeId = Guid.NewGuid(),
                    EmployeeName = "John Doe",
                    LeaveType = "Annual",
                    FromDate = DateTime.Now.AddDays(5),
                    ToDate = DateTime.Now.AddDays(10),
                    Status = "Approved"
                },
                new() {
                    EmployeeId = Guid.NewGuid(),
                    EmployeeName = "Jane Smith",
                    LeaveType = "Sick",
                    FromDate = DateTime.Now,
                    ToDate = DateTime.Now.AddDays(2),
                    Status = "Pending"
                }
            };

            return Task.FromResult(teamLeave.AsEnumerable());
        }

        public Task<IEnumerable<PendingApprovalDTO>> GetPendingApprovalsAsync(Guid managerId)
        {
            // Dummy data
            var approvals = new List<PendingApprovalDTO>
            {
                new() {
                    RequestId = Guid.NewGuid(),
                    EmployeeId = Guid.NewGuid(),
                    EmployeeName = "Mike Johnson",
                    RequestType = "Leave",
                    RequestDate = DateTime.Now,
                    Details = "Annual Leave for 3 days"
                },
                new() {
                    RequestId = Guid.NewGuid(),
                    EmployeeId = Guid.NewGuid(),
                    EmployeeName = "Sarah Wilson",
                    RequestType = "Overtime",
                    RequestDate = DateTime.Now,
                    Details = "Weekend work - 8 hours"
                }
            };

            return Task.FromResult(approvals.AsEnumerable());
        }
    }
}