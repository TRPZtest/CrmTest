using System;
using System.Collections.Generic;

namespace CrmTest.Data.CrmData.Entities;

public partial class Employee
{
    public int Id { get; set; }

    public string FullName { get; set; } = null!;

    public int SubvisionId { get; set; }

    public int PositionId { get; set; }

    public int? PeoplePartnerId { get; set; }

    public int OutOfOfficeBalance { get; set; }

    public bool IsActive { get; set; }

    public byte[]? Photo { get; set; }

    public virtual ICollection<ApprovalRequest> ApprovalRequests { get; set; } = new List<ApprovalRequest>();

    public virtual ICollection<Employee> InversePeoplePartner { get; set; } = new List<Employee>();

    public virtual ICollection<LeaveRequest> LeaveRequests { get; set; } = new List<LeaveRequest>();

    public virtual Employee? PeoplePartner { get; set; }

    public virtual Position Position { get; set; } = null!;

    public virtual Subdivision Subvision { get; set; } = null!;
}
