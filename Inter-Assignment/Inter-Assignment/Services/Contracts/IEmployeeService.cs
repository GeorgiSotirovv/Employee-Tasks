using Inter_Assignment.Models.EmployeeModels;

namespace Inter_Assignment.Services.Contracts
{
    public interface IEmployeeService
    {
        Task<IEnumerable<EmployeeViewModel>> GetAllEmployeesAsync();

        Task AddEmployeeAsync(EmployeeViewModel model);

        public void EditEmployeeInformation(EmployeeViewModel targetEmployee);

        Task RemoveEmployeeFromDatabaseAsync(int ashtrayId);

        Task<EmployeeViewModel> GetInformationForEmployee(int employeeId);
    }
}
