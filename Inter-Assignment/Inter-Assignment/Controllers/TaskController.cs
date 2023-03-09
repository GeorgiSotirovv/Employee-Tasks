using Inter_Assignment.Models.TaskModels;
using Inter_Assignment.Services.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace Inter_Assignment.Controllers
{
    public class TaskController : Controller
    {
        private readonly ITaskService taskService;

        public TaskController(ITaskService _TaskService)
        {
            taskService = _TaskService;
        }

        [HttpGet]
        public async Task<IActionResult> Task()
        {

            var model = await taskService.GetAllTasksAsync();

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> AddTask()
        {
            var model = new TaskViewModel()
            {
                Employees = await taskService.GetEmployeeAsync()
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> AddTask(TaskViewModel model)
        {
            try
            {
                await taskService.AddTasksAsync(model);

                return RedirectToAction(nameof(Task));
            }
            catch (Exception)
            {
                return View(model);
            }
        }

        public async Task<IActionResult> RemoveTask(int employeeId)
        {
            await taskService.RemoveTaskFromDatabaseAsync(employeeId);

            return RedirectToAction(nameof(Task));
        }

        [HttpGet]
        public async Task<IActionResult> EditTask(int Id)
        {
            var targetTask = await taskService.GetInformationForTask(Id);

            var model = new TaskViewModel()
            {
                Id = Id,
                Title = targetTask.Title,
                Description = targetTask.Description,
                DueDate = targetTask.DueDate,
                EmployeId = targetTask.EmployeId,
                Employees = targetTask.Employees,
            };

            return View(model);
        }


        [HttpPost]
        public IActionResult EditTask(int Id, TaskViewModel targetTask)
        {
            if (targetTask == null)
            {
                return View();
            }

            taskService.EditTaskInformation(targetTask);

            return RedirectToAction(nameof(Task));
        }
    }
}
