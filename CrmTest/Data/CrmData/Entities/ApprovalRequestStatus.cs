using System;
using System.Collections.Generic;

namespace CrmTest.Data.CrmData.Entities;

public partial class ApprovalRequestStatus
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<ApprovalRequest> ApprovalRequests { get; set; } = new List<ApprovalRequest>();
}
