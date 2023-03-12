using Inter_Assignment.Data.Models;
using Inter_Assignment.Models.EmployeeModels;
using Inter_Assignment.Models.TaskModels;

namespace Inter_Assignment.Services.Contracts
{
    public interface ITaskService
    {
        //This Method give us all Tasks from database
        Task<IEnumerable<TaskViewModel>> GetAllTasksAsync();

        //This Method add newly created task to the database
        System.Threading.Tasks.Task AddTasksAsync(TaskViewModel model);

        //This Method edit task from database
        public void EditTaskInformation(TaskViewModel targeTask, int IsCompletedId);

        //This Method remove directly from database
        System.Threading.Tasks.Task RemoveTaskFromDatabaseAsync(int taskId);

        //This Method give us information for Task from database
        Task<TaskViewModel> GetInformationForTask(int taskId);

        //This Method give us all Employee
        Task<IEnumerable<Employee>> GetEmployeeAsync();
    }
}
