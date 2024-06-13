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

        public async Task<Employee> GetByIdAsync(int id)
        {
            var employee = await _context.Employees.FindAsync(id);

            return employee;
        }

        public async Task<List<Subdivision>> GetAllSubdivisionsAsync()
        {
            var subdivisions = await _context.Subdivisions.AsNoTracking().ToListAsync();

            return subdivisions;
        }

        public async Task<List<Position>> GetAllPositionsAsync()
        {
            var positions = await _context.Positions.AsNoTracking().ToListAsync();

            return positions;   
        }

        public async Task<List<Employee>> GetByPositionAsync(string positionName)
        {
            var employees = await _context.Employees
                .Where(x => x.Position.Name == positionName)
                .AsNoTracking()
                .ToListAsync();

            return employees;
        }

        public async Task AddEmployeeAsync(Employee employee)
        {
            await _context.Employees.AddAsync(employee);

            await _context.SaveChangesAsync();
        }

        public async Task UpdateEmployeeAsync(Employee employee)
        {
            _context.Employees.Update(employee);

            await _context.SaveChangesAsync();
        }
    }
}
