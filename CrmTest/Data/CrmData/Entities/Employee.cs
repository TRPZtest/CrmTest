using System;
using System.Collections.Generic;

namespace CrmTest.Data.CrmData.Entities;

public partial class Employee
{
    public int Id { get; set; }

    public int? UserId { get; set; }

    public string FullName { get; set; } = null!;

    public int SubvisionId { get; set; }

    public int PositionId { get; set; }

    public int? PeoplePartnerId { get; set; }

    public int OutOfOfficeBalance { get; set; }

    public bool IsActive { get; set; }

    public byte[]? Photo { get; set; }

    public virtual ICollection<Employee> InversePeoplePartner { get; set; } = new List<Employee>();

    public virtual Employee? PeoplePartner { get; set; }

    public virtual Position Position { get; set; } = null!;

    public virtual Subdivision Subvision { get; set; } = null!;
}
