using System;
using System.Collections.Generic;

namespace CrmTest.Data.CrmData.Entities;

public partial class LeaveRequest
{
    public int Id { get; set; }

    public int EmployeeId { get; set; }

    public int AbsenceReasonId { get; set; }

    public DateOnly StartDate { get; set; }

    public DateOnly EndDate { get; set; }

    public string? Comment { get; set; }

    public virtual AbsenceReason AbsenceReason { get; set; } = null!;

    public virtual ICollection<ApprovalRequest> ApprovalRequests { get; set; } = new List<ApprovalRequest>();

    public virtual Employee Employee { get; set; } = null!;
}
