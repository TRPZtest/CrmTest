using CrmTest.Data.CrmData.Entities;
using CrmTest.Models;
using CrmTest.Services;
using Microsoft.AspNetCore.Mvc;

namespace CrmTest.Controllers
{
    [Route("[controller]/[action]")]
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

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            var viewModel = new AddEditEmployeeModel();
            viewModel.Subdivisions = await _employeesService.GetAllSubdivisionsAsync();
            viewModel.Positions = await _employeesService.GetAllPositionsAsync();
            viewModel.Hrs = await _employeesService.GetByPositionAsync("HR Manager");
            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromForm]Employee employee)
        {
            await _employeesService.AddEmployeeAsync(employee);

            return RedirectToAction("List");
        }

        [HttpGet]
        public async Task<IActionResult> Edit([FromQuery]int id)
        {

            var viewModel = new AddEditEmployeeModel();
            viewModel.Employee = await _employeesService.GetByIdAsync(id);
            viewModel.Subdivisions = await _employeesService.GetAllSubdivisionsAsync();
            viewModel.Positions = await _employeesService.GetAllPositionsAsync();
            viewModel.Hrs = await _employeesService.GetByPositionAsync("HR Manager");
            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Edit([FromForm] Employee employee)
        {
            await _employeesService.UpdateEmployeeAsync(employee);
            return RedirectToAction("List");
        }
    }
}
