using CrmTest.Services;
using Microsoft.AspNetCore.Mvc;

namespace CrmTest.Controllers
{
    public class EmployeesController : Controller
    {
        private readonly EmployeesService _employeesService;

        public EmployeesController(EmployeesService employeesService) 
        {
            _employeesService = employeesService;
        }

        [Route("/Lists/Employees/")]
        public async Task<IActionResult> List()
        {
            var employees = await _employeesService.GetAllAsync();
            return View(employees);
        }
        
    }
}
