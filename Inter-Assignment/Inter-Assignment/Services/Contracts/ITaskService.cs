using Inter_Assignment.Models.TaskModels;

namespace Inter_Assignment.Services.Contracts
{
    public interface ITaskService
    {
        Task<IEnumerable<TaskViewModel>> GetAllTasksAsync();

        Task AddTasksAsync(TaskViewModel model);

        public void EditTaskInformation(TaskViewModel targeTask);

        Task RemoveTaskFromDatabaseAsync(int taskId);

        Task<TaskViewModel> GetInformationForTask(int taskId);

        Task<IEnumerable<TaskViewModel>> GetTaskAsync();
    }
}
