using Inter_Assignment.Models.EmployeeModels;

namespace Inter_Assignment.Services.Contracts
{
    public interface IEmployeeService
    {
        Task<IEnumerable<EmployeeViewModel>> GetAllEmployeesAsync();

        Task AddEmployeeAsync(EmployeeViewModel model);

        public void EditEmployeeInformation(EmployeeViewModel targetAshtray);

        Task RemoveEmployeeFromDatabaseAsync(int ashtrayId);
    }
}
