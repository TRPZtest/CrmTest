using System;
using System.Collections.Generic;

namespace CrmTest.Data.CrmData.Entities;

public partial class ApprovalRequest
{
    public int Id { get; set; }

    public int? ApproverId { get; set; }

    public int LeaveRequestId { get; set; }

    public int StatusId { get; set; }

    public virtual Employee? Approver { get; set; }

    public virtual LeaveRequest LeaveRequest { get; set; } = null!;

    public virtual ApprovalRequestStatus Status { get; set; } = null!;
}
