namespace Inter_Assignment.Services.Contracts
{
    public interface ITaskService
    {
        Task<IEnumerable<Models.TaskModels.TaskViewModel>> GetAllTasksAsync();

        Task AddTasksAsync(Models.TaskModels.TaskViewModel model);

        public void EditTasksInformation(Models.TaskModels.TaskViewModel targetAshtray);

        Task RemoveTaskFromDatabaseAsync(int ashtrayId);
    }
}
