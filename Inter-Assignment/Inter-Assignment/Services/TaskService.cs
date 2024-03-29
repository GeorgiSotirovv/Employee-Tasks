﻿using Inter_Assignment.Data;
using Inter_Assignment.Data.Models;
using Inter_Assignment.Models.EmployeeModels;
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

        public async System.Threading.Tasks.Task AddTasksAsync(TaskViewModel model)
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

        public void EditTaskInformation(TaskViewModel targeTask, int IsCompletedId)
        {
            var task = context.Tasks.
               Where(u => u.Id == targeTask.Id)
               .Include(u => u.Employee)
               .FirstOrDefault();

            if (task == null)
            {
                throw new ArgumentException("Invalid Task");
            }

            if (IsCompletedId == 0)
            {
                targeTask.IsCompleted = false;
            }
            else
            {
                targeTask.IsCompleted = true;
            }

            task.Title = targeTask.Title;
            task.DueDate = targeTask.DueDate;
            task.Description = targeTask.Description;
            task.IsCompleted = targeTask.IsCompleted;
            

            if (task.IsCompleted == true)
            {
                task.Employee.NumberOfCompletedTasks += 1;
            }

            task.EmployeId = targeTask.EmployeId;

            context.SaveChanges();
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
                    EmployeId = m.EmployeId,
                    Employee = m.Employee,
                    IsCompleted = m.IsCompleted
                });
        }


        public async Task<TaskViewModel> GetInformationForTask(int taskId)
        {
            var task = await context.Tasks
                .Where(u => u.Id == taskId)
                .FirstOrDefaultAsync();

            var result = new TaskViewModel
            {
                Id = task.Id,
                Title = task.Title,
                Description = task.Description,
                DueDate = task.DueDate,
                EmployeId = task.EmployeId,
                Employees = this.GetEmployeeAsync().Result,
                Employee = task.Employee,
            };

            return result;
        }

        public async Task<IEnumerable<Employee>> GetEmployeeAsync()
        {
            return await context.Employees.ToListAsync();
        }

        public async System.Threading.Tasks.Task RemoveTaskFromDatabaseAsync(int Id)
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