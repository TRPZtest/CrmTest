using CrmTest.Data.CrmData;
using CrmTest.Data.CrmData.Entities;
using Microsoft.EntityFrameworkCore;

namespace CrmTest.Services
{
    public class EmployeesService
    {
        private readonly CrmContext _context;

        public EmployeesService(CrmContext context) 
        {
            _context = context;
        }   

        public async Task<List<Employee>> GetAllAsync()
        {
            var employees = await _context.Employees
                .Include(x => x.Subvision)
                .Include(x => x.Position)
                .Include(x => x.PeoplePartner)
                .AsNoTracking()
                .ToListAsync();

            return employees;
        }
    }
}
