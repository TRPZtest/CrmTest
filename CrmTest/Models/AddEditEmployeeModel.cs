using CrmTest.Data.CrmData.Entities;
using NuGet.Protocol.Core.Types;

namespace CrmTest.Models
{
    public class AddEditEmployeeModel
    {
        public Employee Employee { get; set; }
        public List<Position> Positions { get; set; }
        public List<Subdivision> Subdivisions { get; set; }
        public List<Employee> Hrs { get; set; }
    }
}
