using CrmTest.Data.CrmData.Entities;
using NuGet.Protocol.Core.Types;
using System.ComponentModel.DataAnnotations;

namespace CrmTest.Models
{
    public class AddEditEmployeeModel
    {
        public EmployeeModel Employee { get; set; } 
        public List<Position> Positions { get; set; }
        public List<Subdivision> Subdivisions { get; set; }
        public List<Employee> Hrs { get; set; }
      
    }   

    public class EmployeeModel : Employee
    {
        [EmailAddress]
        public string Email { get; set; }
    }
}
