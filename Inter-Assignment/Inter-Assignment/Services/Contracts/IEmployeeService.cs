using Inter_Assignment.Data.Models;
using Inter_Assignment.Models.EmployeeModels;

namespace Inter_Assignment.Services.Contracts
{
    public interface IEmployeeService
    {
        //This Method display all Employees
        Task<IEnumerable<EmployeeViewModel>> GetAllEmployeesAsync();

        //This Method add newly created employee to the database
        System.Threading.Tasks.Task AddEmployeeAsync(EmployeeViewModel model);

        //This Method edit employe from database
        public void EditEmployeeInformation(EmployeeViewModel targetEmployee);

        //This Method remove from employee from database
        System.Threading.Tasks.Task RemoveEmployeeFromDatabaseAsync(int Id);

        //This Method take information from database for employee 
        Task<EmployeeViewModel> GetInformationForEmployee(int employeeId);

        //This Method give us top 5 employee with most complited tasks for last mounth
        public Task<IEnumerable<Employee>> GetFiveEmployeeWithMostComplitedTasks();

        //This Method add review to employee
        public EmployeeReviewViewModel AddReview(EmployeeReviewViewModel targetEmployee);

        //This Method get all the Employees from database
        public Task<IEnumerable<Employee>> GetEmployeeAsync();

        //This Method get us all review for given employee
        Task<EmployeeReviewViewModel> GetReviewsAsync(int empId);
    }
}
