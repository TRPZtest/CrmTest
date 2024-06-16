using CrmTest.Data.CrmData;
using CrmTest.Models;

namespace CrmTest.Services
{
    public class AddEditEmployeeModelService
    {
        private readonly EmployeesRepository _repository;

        public AddEditEmployeeModelService(EmployeesRepository repository) 
        {
            _repository = repository;
        }

        public  async Task<AddEditEmployeeModel> GetViewModel()
        {
            var viewModel = new AddEditEmployeeModel();
       
            viewModel.Subdivisions = await _repository.GetAllSubdivisionsAsync();
            viewModel.Positions = await _repository.GetAllPositionsAsync();
            viewModel.Hrs = await _repository.GetByPositionAsync("HR Manager");

            return viewModel;
        }

        public async Task<AddEditEmployeeModel> GetViewModel(int id)
        {
            var viewModel = await GetViewModel();

            viewModel.Employee = await _repository.GetByIdAsync(id) as EmployeeModel;
          
            return viewModel;
        }
    }
}
