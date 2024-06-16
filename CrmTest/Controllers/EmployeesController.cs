using CrmTest.Data.CrmData;
using CrmTest.Data.CrmData.Entities;
using CrmTest.Helpers;
using CrmTest.Models;
using CrmTest.Services;
using Microsoft.AspNetCore.Mvc;

namespace CrmTest.Controllers
{
    [Route("[controller]/[action]")]
    public class EmployeesController : Controller
    {
        private readonly EmployeesRepository _employeesRepository;       
        
        public EmployeesController(EmployeesRepository employeesRepository) 
        {            
            _employeesRepository = employeesRepository;         
        }

        [Route("/Lists/Employees/")]
        public async Task<IActionResult> List()
        {
            var employees = await _employeesRepository.GetAllAsync();
            return View(employees);
        }

        [HttpGet]
        public async Task<IActionResult> Add([FromServices] AddEditEmployeeModelService service)
        {      
            var viewModel = await service.GetViewModel();
          
            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromForm]EmployeeModel employee, [FromServices] AddUserService service)
        {
            await service.AddUserAsync(employee);

            return RedirectToAction("List");
        }

        [HttpGet]
        public async Task<IActionResult> Edit([FromQuery]int id, [FromServices]AddEditEmployeeModelService service)
        {

            var viewModel = await service.GetViewModel(id);
            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Edit([FromForm] Employee model)
        {
            await _employeesRepository.UpdateEmployeeAsync(model);
            return RedirectToAction("List");
        }
    }
}
