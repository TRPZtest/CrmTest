using System;
using System.Collections.Generic;

namespace CrmTest.Data.CrmData.Entities;

public partial class AbsenceReason
{
    public int Id { get; set; }

    public string Text { get; set; } = null!;

    public virtual ICollection<LeaveRequest> LeaveRequests { get; set; } = new List<LeaveRequest>();
}
