using Inter_Assignment.Models.TaskModels;
using Inter_Assignment.Services.Contracts;
using Microsoft.AspNetCore.Mvc;
using static Inter_Assignment.WebConstants;

namespace Inter_Assignment.Controllers
{
    public class TaskController : Controller
    {
        private readonly ITaskService taskService;

        public TaskController(ITaskService _TaskService)
        {
            taskService = _TaskService;
        }

        //This Action display all Task
        [HttpGet]
        public async Task<IActionResult> Task()
        {

            var model = await taskService.GetAllTasksAsync();

            return View(model);
        }

        //This Action load the view of AddTask
        [HttpGet]
        public async Task<IActionResult> AddTask()
        {
            var model = new TaskViewModel()
            {
                Employees = await taskService.GetEmployeeAsync()
            };

            return View(model);
        }

        //This Action add the newly created task
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
                TempData[GlobalExeptionError] = "You forgot to fill some field please try again";

                return RedirectToAction(nameof(AddTask));
            }
        }

        //This Action remove Task from database
        public async Task<IActionResult> RemoveTask(int employeeId)
        {
            await taskService.RemoveTaskFromDatabaseAsync(employeeId);

            return RedirectToAction(nameof(Task));
        }

        //This Action recive Id of the Task and load the model with the information for the Task
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
                IsCompleted = targetTask.IsCompleted,
                Employee = targetTask.Employee
            };

            return View(model);
        }

        //This Action edit the Task
        [HttpPost]
        public IActionResult EditTask(int Id, TaskViewModel targetTask, int IsCompletedId)
        {
            try
            {
                taskService.EditTaskInformation(targetTask, IsCompletedId);

                return RedirectToAction(nameof(Task));
            }
            catch (Exception)
            {
                TempData[GlobalExeptionError] = "You forgot to fill some field please try again";

                return RedirectToAction(nameof(EditTask));
            }  
        }
    }
}
