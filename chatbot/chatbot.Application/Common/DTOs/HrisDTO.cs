using System;
using System.Collections.Generic;

namespace chatbot.Application.DTOs
{
    public class LeaveBalanceDTO
    {
        public decimal AnnualLeave { get; set; }
        public decimal SickLeave { get; set; }
        public decimal CasualLeave { get; set; }
        public decimal UsedAnnual { get; set; }
        public decimal UsedSick { get; set; }
        public decimal UsedCasual { get; set; }
        public decimal RemainingAnnual => AnnualLeave - UsedAnnual;
        public decimal RemainingSick => SickLeave - UsedSick;
        public decimal RemainingCasual => CasualLeave - UsedCasual;
    }

    public class LeaveRequestDTO
    {
        public Guid Id { get; set; }
        public string LeaveType { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
        public string Status { get; set; } // Pending, Approved, Rejected
        public int Days { get; set; }
    }

    public class AttendanceDTO
    {
        public DateTime Date { get; set; }
        public DateTime? CheckIn { get; set; }
        public DateTime? CheckOut { get; set; }
        public string Status { get; set; } // Present, Absent, Late
    }

    public class TeamLeaveStatusDTO
    {
        public Guid EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public string LeaveType { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
        public string Status { get; set; }
    }

    public class PendingApprovalDTO
    {
        public Guid RequestId { get; set; }
        public Guid EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public string RequestType { get; set; } // Leave, OT, etc.
        public DateTime RequestDate { get; set; }
        public string Details { get; set; }
    }
}