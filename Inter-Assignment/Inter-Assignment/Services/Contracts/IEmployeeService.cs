using Inter_Assignment.Data.Models;
using Inter_Assignment.Models.EmployeeModels;

namespace Inter_Assignment.Services.Contracts
{
    public interface IEmployeeService
    {
        Task<IEnumerable<EmployeeViewModel>> GetAllEmployeesAsync();

        System.Threading.Tasks.Task AddEmployeeAsync(EmployeeViewModel model);

        public void EditEmployeeInformation(EmployeeViewModel targetEmployee);

        System.Threading.Tasks.Task RemoveEmployeeFromDatabaseAsync(int ashtrayId);

        Task<EmployeeViewModel> GetInformationForEmployee(int employeeId);

        public Task<IEnumerable<Employee>> GetFiveEmployeeWithMostComplitedTasks();

        public EmployeeReviewViewModel AddReview(EmployeeReviewViewModel targetEmployee);

        public Task<IEnumerable<Employee>> GetEmployeeAsync();

        Task<EmployeeReviewViewModel> GetReviewsAsync(int empId);
    }
}
