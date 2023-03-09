using Inter_Assignment.Data;
using Inter_Assignment.Models.TaskModels;
using Inter_Assignment.Services.Contracts;
using Microsoft.EntityFrameworkCore;

namespace Inter_Assignment.Services
{
    public class TaskService : ITaskService
    {
        private readonly ApplicationDbContext context;

        public TaskService(ApplicationDbContext _context)
        {
            context = _context;
        }

        public async Task AddTasksAsync(TaskViewModel model)
        {
            var entity = new Data.Models.Task()
            {
                Id = model.Id,
                Title = model.Title,
                Description = model.Description,
                DueDate = model.DueDate,
                EmployeId = model.EmployeId,
            };
            await context.Tasks.AddAsync(entity);
            await context.SaveChangesAsync();
        }

        public void EditTasksInformation(TaskViewModel targeTask)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<TaskViewModel>> GetAllTasksAsync()
        {
            var task = await context.Tasks
                .Include(x => x.Employee)
                .ToListAsync();

            return task
                .Select(m => new TaskViewModel()
                {
                    Id = m.Id,
                    Title = m.Title,
                    Description = m.Description,
                    DueDate = m.DueDate,
                    EmployeId = m.EmployeId
                });
        }

        public async Task<IEnumerable<TaskViewModel>> GetEmployeeAsync()
        {
            return (IEnumerable<TaskViewModel>)context.Employees.ToListAsync();
        }

        public async Task RemoveTaskFromDatabaseAsync(int Id)
        {
            var task = await context.Tasks
                .Where(u => u.Id == Id)
                .FirstOrDefaultAsync();


            if (task == null)
            {
                throw new ArgumentException("Invalid Task");
            }

            context.Tasks.Remove(task);

            await context.SaveChangesAsync();
        }
    }
}
