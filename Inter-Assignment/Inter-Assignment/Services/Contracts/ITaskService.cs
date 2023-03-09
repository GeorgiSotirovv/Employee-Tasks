using Inter_Assignment.Data.Models;
using Inter_Assignment.Models.EmployeeModels;
using Inter_Assignment.Models.TaskModels;

namespace Inter_Assignment.Services.Contracts
{
    public interface ITaskService
    {
        Task<IEnumerable<TaskViewModel>> GetAllTasksAsync();

        System.Threading.Tasks.Task AddTasksAsync(TaskViewModel model);

        public void EditTaskInformation(TaskViewModel targeTask);

        System.Threading.Tasks.Task RemoveTaskFromDatabaseAsync(int taskId);

        Task<TaskViewModel> GetInformationForTask(int taskId);

        Task<IEnumerable<Employee>> GetEmployeeAsync();
    }
}
